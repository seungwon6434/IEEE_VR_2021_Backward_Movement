using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

using Debug = UnityEngine.Debug;

public class Ball_Movement_SP : MonoBehaviour
{
    RaycastHit rayHit;
    Ray ray;
    public List<Transform> paths_player = new List<Transform>();

    int[] actions = new int[] { 3, 3, 3, 3, 3, 3, 3, 1, 1, 1, 2, 2, 2, 4, 4, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
    int action = 0;

    public Stopwatch sw_follower;
    public Stopwatch sw_follower_total;

    

    void Awake()
    {
        //Nodes = GameObject.FindGameObjectsWithTag("normal");
        sw_follower = new Stopwatch();
        sw_follower_total = new Stopwatch();

        sw_follower.Start();
        sw_follower_total.Start();
    }

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().btnFindPath();

    }

    void FixedUpdate()
    {
        
        /*
        //print(sw_follower.ElapsedMilliseconds);

        if (sw_follower.ElapsedMilliseconds >= 2000) // 2초에 한번 움직이기
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

    private void MoveUp()
    {
        ray.direction = this.transform.forward;


        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 5f);


        // print(Physics.Raycast(transform.position, ray.direction, out rayHit, 3f));

        // print(this.transform.position);
        //Debug.Log(ray.direction);
        // print(rayHit.ToString());

        if (Physics.Raycast(transform.position, ray.direction, out rayHit, 1.5f))
        {
            //Debug.Log("움직임?");
            //  Debug.Log(rayHit.collider.gameObject);

            bool h = rayHit.collider.gameObject.CompareTag("block");
            bool f = rayHit.collider.gameObject.CompareTag("fire");

            //   Debug.Log(h);
            //  Debug.Log(f);

            if (!h && !f)
            {
                //Debug.Log(rayHit.distance);
                transform.position = rayHit.collider.gameObject.transform.position;

                GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().setNode(rayHit.collider.gameObject.transform, GameObject.Find("node (end)").transform);
                GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().btnFindPath();
                //  Debug.Log(this.transform.position);
            }

        }
    }

    private void MoveDown()
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

                GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().setNode(rayHit.collider.gameObject.transform, GameObject.Find("node (end)").transform);
                GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().btnFindPath();
            }

        }
    }

    private void MoveRight()
    {
        ray.direction = this.transform.right;
        //Debug.Log(ray.direction);

        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 5f);
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

                GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().setNode(rayHit.collider.gameObject.transform, GameObject.Find("node (end)").transform);
                GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().btnFindPath();
            }

        }
    }

    private void MoveLeft()
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

                GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().setNode(rayHit.collider.gameObject.transform, GameObject.Find("node (end)").transform);
                GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().btnFindPath();
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

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Node"))
        {
            paths_player = GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().paths;
            foreach (Transform path in paths_player)
            {
                Renderer rend = path.GetComponent<Renderer>();
               // rend.material.color = Color.white;
                // rend.gameObject.tag = "Node";
            }

            //    Debug.Log(other.gameObject);
            //Debug.Log("노드 태그");
            GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().setNode(other.gameObject.transform, GameObject.Find("node (end)").transform);
            //Debug.Log(other.gameObject);


        }

        else if (other.CompareTag("end"))
        {
            Debug.Log("앤드 태그");

        }

        else if (other.CompareTag("start"))
        {
            Debug.Log("스타트 태그");

        }
    }

}
