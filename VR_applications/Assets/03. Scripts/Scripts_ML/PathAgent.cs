using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using System.Diagnostics;

using Debug = UnityEngine.Debug;

public class PathAgent : Agent
{
    private Rigidbody ballRigidbody; // 볼의 리지드 바디
    public Transform pivotTransform; // 위치의 기준점
    public Transform target; // 아이템 목표
    public float moveForce = 10f; // 이동 힘
    public bool targetEaten = false; // 목표를 먹었는지
    public bool dead = false; // 사망상태
    public bool start = false; // 사망상태
    public bool block = false;

    float distance;
    RaycastHit rayHit;
    Ray ray;

    private const int NoAction = 0;  // do nothing!
    private const int Up = 1;
    private const int Down = 2;
    private const int Left = 3;
    private const int Right = 4;

    public Rigidbody rb;

    private Stopwatch sw_total;
    private Stopwatch sw_temp;

    private float distances = 0;
    private float dis_val = 0;
    private bool tofire = false;


    public GameObject[] fires;

    public List<GameObject> paths_ML = new List<GameObject>();

    public bool follow_target;

    public LayerMask layerMask;

    private Vector3 Direction = Vector3.zero;

    void Awake()
    {
        ballRigidbody = GetComponent<Rigidbody>();
        start = true;

        ray = new Ray();
        ray.origin = this.transform.position;

        rb = GetComponent<Rigidbody>();

        sw_total = new Stopwatch();
        sw_temp = new Stopwatch();
    }

    void ResetTarget()
    {
        targetEaten = false;
        sw_temp.Start();
    }

    public override void AgentReset() // Agent가 리셋을 할때의 상태 재설정 하는 느깜  
    {
        sw_total.Start();
        sw_temp.Start();

        transform.position = GameObject.Find("Player").transform.position + pivotTransform.position;

        //Vector3 randomPos = new Vector3(0, 0, 0);
        //transform.position = randomPos + pivotTransform.position;

        dead = false;
        ballRigidbody.velocity = Vector3.zero;
    }

    public override void CollectObservations() // 중요한 정보들을 저장하기 위한 함수
    {

        Vector3 distanceToTarget = target.position - transform.position;

        AddVectorObs(Mathf.Clamp(distanceToTarget.x / 5f, -1f, 1f)); // 타겟과의 거리
        AddVectorObs(Mathf.Clamp(distanceToTarget.z / 5f, -1f, 1f));

        Vector3 relativePos = transform.position - pivotTransform.position;

        AddVectorObs(Mathf.Clamp(relativePos.x / 5f, -1f, 1f)); // 출발점과의 거리
        AddVectorObs(Mathf.Clamp(relativePos.z / 5f, -1f, 1f));

        AddVectorObs(Mathf.Clamp(ballRigidbody.velocity.x / 10f, -1f, 1f));
        AddVectorObs(Mathf.Clamp(ballRigidbody.velocity.z / 10f, -1f, 1f));

        fires = GameObject.FindGameObjectsWithTag("fire");

        AddVectorObs(DistancetoFire());
        distances = 0;

    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        AddReward(-0.01f);

        //----------------------------------------------------------------------------------
        //------------------------------- 이동 과정 ----------------------------------------
        //----------------------------------------------------------------------------------

        int action = Mathf.FloorToInt(vectorAction[0]);
      
        if (action == 4) MoveDirection(this.transform.right); // 오른쪽
        else if (action == 3) MoveDirection(this.transform.right * -1); // 왼쪽
        else if (action == 1) MoveDirection(this.transform.forward); // 위
        else if (action == 2) MoveDirection(this.transform.forward * -1); // 아래

        //----------------------------------------------------------------------------------
        //------------------------------- Reward 과정 --------------------------------------
        //----------------------------------------------------------------------------------

        if (RayDirect())
        {
            tofire = true;
            Direction = ray.direction;
            AddReward(-0.1f);
        }

        if (tofire)
        {
            if (Direction != ray.direction) 
            {
                AddReward(0.2f);
                tofire = false;
            }    
            else
                AddReward(-0.1f);
        }


        var follower_total = GameObject.Find("Player").GetComponent<Follower>().sw_follower_total;
        //print(GameObject.FindGameObjectsWithTag("fire")[0]);

        if (follower_total.ElapsedMilliseconds > 200)
        {
            GameObject.Find("PathMake").GetComponent<GridGenerate>().UpdateFire();
            follower_total.Restart();
        }


        if (true) 
        {
            if (DistancetoFire() < 4.0)
                AddReward(-0.1f);

            if (targetEaten) // Agent가 길을 찾는데 성공
            {

                // Debug.Log("Agent가 길찾기 성공!");
                Debug.Log(sw_total.ElapsedMilliseconds);

                sw_total.Reset();
                sw_temp.Reset();

                // 살려야 함
                //GameObject.Find("PathMake").GetComponent<GridGenerate>().UpdateFire();

                //GameObject.Find("Player").GetComponent<Follower>().setTarget(true);

                var temp = getGreen().Count;

                if (temp < 20)
                    AddReward(0.1f);

                AddReward(2.0f);

                ResetTarget();
                AgentReset();

                Done();

            }


            else if (sw_temp.ElapsedMilliseconds > 10000) // 시간이 2초가 넘어가는 경우
            {
                AddReward(-0.1f);

                //ResetRoute();
                //GameObject.Find("PathMake").GetComponent<GridGenerate>().UpdateFire();

                sw_temp.Reset();
                ResetTarget();

            }

            /*
            else if (FireinRoute())
            {
                ResetRoute();
            }
            */

            else if (block)
            {
                //AddReward(-0.1f);
                block = false;

            }

            else if (start)
            {
                AddReward(-0.01f);

            }

        }

    }

    public void MoveDirection(Vector3 dir) 
    {
        ray.direction = dir;

        if (Physics.Raycast(transform.position, ray.direction, out rayHit, 2f))
        {
            //Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 5f);

            bool h = rayHit.collider.gameObject.CompareTag("block");
            bool f = rayHit.collider.gameObject.CompareTag("fire");

            if (!h && !f)
            {
                transform.position = rayHit.collider.gameObject.transform.position;
            }
            else block = true;
        }
    }

    public float DistancetoFire()
    {
        var obs = GameObject.FindGameObjectsWithTag("fire");
        float reward_distances = 0;

        // --------------------------------------------- fire들과의 거리 계산 -----------------------------------
        foreach (GameObject ob in obs)
        {
            // print(fire);

            Vector3 distanceToblock = ob.transform.position - transform.position;
            float distance = Vector3.Distance(ob.transform.position, transform.position);

            reward_distances += distance;
        }

        float result = reward_distances / (obs.Length);
        //-------------------------------------------------------------------------------------------------------

        return result;
    }

    public List<GameObject> getGreen()
    {
        //print("겟 그린");
        //print(paths_ML.Count);

        return paths_ML;

    }

    public void flushGreen()
    {

        foreach (var p in paths_ML)
        {
            if (!p.CompareTag("fire")) 
            {
                p.GetComponent<MeshRenderer>().material.color = Color.white;
                p.gameObject.tag = "normal";
            }
            
        }

        paths_ML.Clear();
    }

    public void ResetPosition()
    {
        transform.position = GameObject.Find("Player").transform.position + pivotTransform.position;
    }

    public void ResetRoute()
    {

        GameObject.Find("Player").GetComponent<Follower>().setTrigger(false);

        flushGreen();
        ResetPosition();

        GameObject.Find("Player").GetComponent<Follower>().setTrigger(true);



    }

    public bool FireinRoute()
    {
        foreach (var p in paths_ML)
        {
            if (p.CompareTag("fire"))
            {
                return true;
            }
        }

        return false;

    }

    public bool RayDirect() // 가던 방향에 불이 있는지 없는지 검사하는 함수
    {
//        print(ray.direction);

        if (Physics.Raycast(transform.position, ray.direction * 15, out rayHit, 10f, layerMask))
        {
            //Debug.DrawRay(transform.position, ray.direction, Color.red, 15f);

            bool H = rayHit.collider.gameObject.CompareTag("fire");

            //print(rayHit.collider.gameObject);
            //print(H);

            return true;
        }

        return false;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("normal"))
        {
            bool temp = GameObject.Find("Player").GetComponent<Follower>().trigger;

            if (temp)
            {
                //print("온트리거 템프");
                paths_ML.Add(other.gameObject);
            }
            // 경로 추가를 위해 방문한 노드 추가
        }

        else if (other.CompareTag("end")) 
        {

            //print("TargetEaten");
            targetEaten = true;

        } 

        else if (other.CompareTag("start"))
        {

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("block"))
        {

        }

    }

}