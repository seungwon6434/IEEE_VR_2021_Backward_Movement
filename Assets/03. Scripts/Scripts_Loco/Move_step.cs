using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Move_step : MonoBehaviour
{
    public GameObject TCP;

    public float movementSpeed = 5.0f;

    private Transform camTr;
    private Transform Left;
    private Transform Right;

    private float Right_before = 0;
    private float Left_before = 0;

    private float Right_after = 0;
    private float Left_after = 0;

    public string state = "Default";
    private bool trigger = true;

    private Vector3 forback = Vector3.forward;

    public SteamVR_Action_Boolean grabPinch;

    public bool Test = true;


    // Start is called before the first frame update
    void Start()
    {
        camTr = GameObject.Find("Camera").GetComponent<Transform>();
        Right = GameObject.Find("Rightfoot").GetComponent<Transform>();
        Left = GameObject.Find("Leftfoot").GetComponent<Transform>();

        

    }

    // Update is called once per frame
    void Update()
    {
        //print(Test);
        //Right_after = Right.position.y;
        //Left_after = Left.position.y;

        Right_after = Right.localPosition.y;
        Left_after = Left.localPosition.y;

        float temp = Right_after - Right_before;

        //var result = TCP.GetComponent<TCPTestClient>().result;

        //print("디렉션 : "+temp_1);

        //---------------------- Test 할때 -------------------------
    

            var temp_1 = TCP.GetComponent<TCPTestClient>().result;
            print(temp_1);

            if (temp_1 == " Forward")
            {
                //print("Forward");
                state = "Forward";
                step_move_forward();
            }

            else if (temp_1 == " Backward")
            {
                //print("다른 거");s
                state = "Backward";
                step_move_back();
            }

        
        //------------------------ Train 할때 ------------------------
        /*
      
            if (grabPinch.state == false)
            {
                state = "Forward";
                step_move_forward();
            }

            else
            {
                state = "Backward";
                step_move_back();
            }
        

            */
        //--------------------------------------------------------

        //Right_before = Right.position.y;
        //Left_before = Left.position.y;

        Right_before = Right.localPosition.y;
        Left_before = Left.localPosition.y;
    }

    private void Move()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        //print(dir);

        if (Input.GetKey(KeyCode.W))
        {
            dir = camTr.TransformDirection(Vector3.forward);
            dir.y = 0;
            transform.position += dir * Time.deltaTime * movementSpeed;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            dir = camTr.TransformDirection(-1 * Vector3.forward);
            dir.y = 0;
            transform.position += dir * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            dir = camTr.TransformDirection(-1 * Vector3.right);
            dir.y = 0;
            transform.position += dir * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir = camTr.TransformDirection(Vector3.right);
            dir.y = 0;
            transform.position += dir * Time.deltaTime * movementSpeed;
        }
        else
        {
        }
    }
    private void step_move_forward()
    {
        if ((Right_after - Right_before > 0.005))
        {
            //print("오른발 움직일걸");

            Vector3 dir1 = camTr.TransformDirection(Vector3.forward);
            dir1.y = 0;
            transform.position += dir1 * Time.deltaTime * movementSpeed;
        }

        if (Left_after - Left_before > 0.003)
        {
            // print("왼발 움직일걸");

            Vector3 dir2 = camTr.TransformDirection(Vector3.forward);
            dir2.y = 0;
            transform.position += dir2 * Time.deltaTime * movementSpeed;
        }
    }

    private void step_move_back()
    {
        if ((Right_after - Right_before > 0.003))
        {
            //print("오른발 움직일걸");

            Vector3 dir1 = camTr.TransformDirection(-1 * Vector3.forward);
            dir1.y = 0;
            transform.position += dir1 * Time.deltaTime * movementSpeed;
        }

        if (Left_after - Left_before > 0.003)
        {
            //print("왼발 움직일걸");

            Vector3 dir2 = camTr.TransformDirection(-1 * Vector3.forward);
            dir2.y = 0;
            transform.position += dir2 * Time.deltaTime * movementSpeed;
        }
    }
}
