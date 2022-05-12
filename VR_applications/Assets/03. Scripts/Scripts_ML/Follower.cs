using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using System.Diagnostics;

using Debug = UnityEngine.Debug;

public class Follower : MonoBehaviour
{
    RaycastHit rayHit;
    Ray ray;

    public List<Transform> paths_player = new List<Transform>();
    private Transform temp;

    public Transform pivotTransform; // 위치의 기준점

    public bool target = false;
    public bool trigger = true;

    public List<GameObject> paths_green = new List<GameObject>();
    public List<GameObject> check_green = new List<GameObject>();

    public GameObject[] Nodes;

    public LayerMask layerMask;

    public Stopwatch sw_follower;
    public Stopwatch sw_follower_total;

    private int act = 0;

    int[] actions = new int[] { 3, 3, 3, 3, 3, 3, 3, 1, 1, 1, 2, 2, 2, 4, 4, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
    int action = 0;

    void Awake()
    {
        //Nodes = GameObject.FindGameObjectsWithTag("normal");
        sw_follower = new Stopwatch();
        sw_follower_total = new Stopwatch();
    }

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position;
        temp = this.transform;

        Nodes = GameObject.FindGameObjectsWithTag("normal");
        sw_follower_total.Start();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        UnityEngine.Random.seed = 12;
        print("팔로워 업데이트");
        print(UnityEngine.Random.Range(0, 10));
        print(UnityEngine.Random.Range(0, 10));
        */

        Move(); // 훈련할 떄는 꺼두기

        bool targetEaten = GameObject.Find("Sphere").GetComponent<PathAgent>().targetEaten;
        // print("템프");            
        //print(targetEaten + " " + (!target).ToString() + " " + trigger.ToString());

        //if (targetEaten) Train_Move();  //훈련할 떄만

        if (targetEaten && !target && trigger)  // Agent가 길을 찾는데 성공, Follwer는 이제 따라가야함. 
        {
            print("---------IN---------");

            trigger = false;

            paths_green = GameObject.Find("Sphere").GetComponent<PathAgent>().getGreen();

            //print(paths_green.Count);
            int i = 0;
            foreach (var G in paths_green)
            {
                //   print(i.ToString() + "번째 : " + G.ToString());
                G.GetComponent<MeshRenderer>().material.color = Color.green;
                i++;
            }


            // GameObject.Find("Sphere").GetComponent<PathAgent>().getGreen().Clear();

            // Vector3 randomPos = new Vector3(0, 0, 0);
            // transform.position = randomPos + pivotTransform.position;

        }

        else if (target) // 타겟이 목적지에 도달 함
        {
            print("---------IN Target---------");
            ResetGreen();
            GameObject temp = GameObject.Find("Sphere"); //이유는 모르겠지만, 복잡한 충돌이 일어남

            //Vector3 randomPos = this.transform.position;

            temp.transform.position = new Vector3(0, 0, 0);
            //temp.transform.position = randomPos;

            trigger = true;
            target = false;
        }

    }

    void FixedUpdate()
    {
        /*
        sw_follower.Start();
        
        //print(sw_follower.ElapsedMilliseconds);

        if (sw_follower.ElapsedMilliseconds >= 3000) 
        {
            if (action < actions.Length) 
            {
                MoveNum(actions[action]);
                action++;
                sw_follower.Restart();
            }
            
        }
        */

}

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) MoveUp();
        else if (Input.GetKeyDown(KeyCode.DownArrow)) MoveDown();
        else if (Input.GetKeyDown(KeyCode.RightArrow)) MoveRight();
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) MoveLeft();
    }

    public void MoveTrain(int i)
    {

        transform.position = Nodes[i].transform.position;

    }

    public void Train_Move()
    {
        if (act < Nodes.Length)
        {
            MoveTrain(act);
            act++;
        }

        else act = 0;
    }


    public void ResetGreen()
    {
        paths_green = GameObject.Find("Sphere").GetComponent<PathAgent>().getGreen();

        foreach (var G in paths_green)
        {
            G.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        paths_green.Clear();
    }

    public void MoveUp()
    {
        ray.direction = this.transform.forward;


        //Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 5f);


        // print(Physics.Raycast(transform.position, ray.direction, out rayHit, 3f));

        // print(this.transform.position);
        //Debug.Log(ray.direction);
        // print(rayHit.ToString());

        if (Physics.Raycast(transform.position, ray.direction, out rayHit, 1.5f))
        {
            //Debug.Log("움직임?");
            //Debug.Log(rayHit.collider.gameObject);

            bool h = rayHit.collider.gameObject.CompareTag("block");
            bool f = rayHit.collider.gameObject.CompareTag("fire");

            //   Debug.Log(h);
            //  Debug.Log(f);

            if (!h && !f)
            {
                //Debug.Log(rayHit.distance);
                transform.position = rayHit.collider.gameObject.transform.position;

                //if (GameObject.Find("Sphere").GetComponent<PathAgent>().FireinRoute())
                GameObject.Find("Sphere").GetComponent<PathAgent>().ResetRoute();
                //else
                //    GameObject.Find("Sphere").GetComponent<PathAgent>().ResetPosition();
                //Debug.Log(this.transform.position);
            }

        }
    }

    public void MoveDown()
    {
        ray.direction = this.transform.forward * -1;
        //Debug.Log(ray.direction);



        if (Physics.Raycast(transform.position, ray.direction, out rayHit, 1.5f))
        {
            // Debug.Log(rayHit.collider.gameObject.tag);

            bool h = rayHit.collider.gameObject.CompareTag("block");
            bool f = rayHit.collider.gameObject.CompareTag("fire");
            //Debug.Log(h);

            if (!h && !f)
            {
                //Debug.Log(rayHit.distance);
                transform.position = rayHit.collider.gameObject.transform.position;

                //if (GameObject.Find("Sphere").GetComponent<PathAgent>().FireinRoute())
                GameObject.Find("Sphere").GetComponent<PathAgent>().ResetRoute();
                //else
                //    GameObject.Find("Sphere").GetComponent<PathAgent>().ResetPosition();
            }

        }
    }

    public void MoveRight()
    {
        ray.direction = this.transform.right;
        //Debug.Log(ray.direction);

        //Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 5f);
        //print(Physics.Raycast(transform.position, ray.direction, out rayHit, 2f));

        if (Physics.Raycast(transform.position, ray.direction, out rayHit, 1.5f))
        {
            //Debug.Log(rayHit.collider.gameObject.tag);

            bool h = rayHit.collider.gameObject.CompareTag("block");
            bool f = rayHit.collider.gameObject.CompareTag("fire");
            //Debug.Log(h);

            if (!h && !f)
            {
                //Debug.Log(rayHit.distance);
                transform.position = rayHit.collider.gameObject.transform.position;

                //if (GameObject.Find("Sphere").GetComponent<PathAgent>().FireinRoute())
                GameObject.Find("Sphere").GetComponent<PathAgent>().ResetRoute();
                //else
                //    GameObject.Find("Sphere").GetComponent<PathAgent>().ResetPosition();
            }

        }
    }

    public void MoveLeft()
    {
        ray.direction = this.transform.right * -1;
        //Debug.Log(ray.direction);

        if (Physics.Raycast(transform.position, ray.direction, out rayHit, 1.5f))
        {
            //Debug.Log(rayHit.collider.gameObject.tag);

            bool h = rayHit.collider.gameObject.CompareTag("block");
            bool f = rayHit.collider.gameObject.CompareTag("fire");
            //Debug.Log(h);

            if (!h && !f)
            {
                //Debug.Log(rayHit.distance);
                transform.position = rayHit.collider.gameObject.transform.position;

                //if (GameObject.Find("Sphere").GetComponent<PathAgent>().FireinRoute())
                GameObject.Find("Sphere").GetComponent<PathAgent>().ResetRoute();
                //else
                //    GameObject.Find("Sphere").GetComponent<PathAgent>().ResetPosition();
            }

        }
    }

    public void MoveNum(int i) 
    {
        switch (i) 
        {
            case 1: MoveUp(); break;
            case 2: MoveDown(); break;
            case 3: MoveRight(); break;
            case 4: MoveLeft(); break;
        }
            
    }


    void OnTriggerEnter(Collider col)
    {


        if (col.CompareTag("normal"))
        {
            // print("팔로워의 노드방문");
        }

        else if (col.CompareTag("end"))
        {
            print("엔드 트리거");
            setTarget(true);
        }

        else if (col.CompareTag("start"))
        {

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Node"))
        {

        }

        else if (other.transform.CompareTag("end"))
        {
            print("엔드 콜리젼");
            setTarget(true);
        }

        else if (other.transform.CompareTag("start"))
        {

        }
    }

    public void setTarget(bool result)
    {
        target = result;
    }

    public bool getTarget()
    {
        return target;
    }

    public void setTrigger(bool result)
    {
        trigger = result;
    }

    public bool getTrigger()
    {
        return trigger;
    }

}