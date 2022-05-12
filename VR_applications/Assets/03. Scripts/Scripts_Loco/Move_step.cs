using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Valve.VR;

public class Move_step : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    private Transform camTr;
    private Transform Left;
    private Transform Right;

    private Transform Center;

    private float Right_before = 0;
    private float Left_before = 0;

    private float Right_after = 0;
    private float Left_after = 0;

    public string state = "Default";
    private bool trigger = true;

    private Vector3 forback = Vector3.forward;

    public SteamVR_Action_Boolean grabPinch;


    // Start is called before the first frame update
    void Start()
    {
        camTr = GameObject.Find("Camera").GetComponent<Transform>();
        Right = GameObject.Find("Rightfoot").GetComponent<Transform>();
        Left = GameObject.Find("Leftfoot").GetComponent<Transform>();
        Center = GameObject.Find("Center").GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {

        var direction = camTr.forward;
        Debug.DrawRay(camTr.position, direction * 15, Color.red);

        //------------------------------------------------------------

        Right_after = Right.position.y;
        Left_after = Left.position.y;

        float temp = Right_after - Right_before;

        //print("디렉션 : "+temp_1);

        //---------------------- Test 할때 -------------------------



        var temp_1 = GameObject.Find("Client").GetComponent<TCPTestClient>().temp;

        if (temp_1 == "1")
        {
            //print("Forward");
            state = "Forward";
            step_move_forward();
        }

        else if (temp_1 == "0")
        {
            //print("다른 거");
            state = "Backward";
            step_move_back();
        }

        else if (temp_1 == " Backward")
        {
            //print("다른 거");
            state = "Backward";
            step_move_back();
        }

        else if (temp_1 == " Forward")
        {
            //print("다른 거");
            state = "Forward";
            step_move_forward();
        }



        //------------------------ Train 할때 ------------------------

        /*
        if (grabPinch.state == true)
        {
            //print("누름");
            state = "Forward";
            step_move_forward();
        }

        else {
            state = "Backward";
            step_move_back();
        }
          */


        //--------------------------Final Train------------------------------

        /*
        Vector3 cam_vector = camTr.TransformDirection(Vector3.forward);
        cam_vector.y = 0;

        Vector3 heading_right = Right.transform.localPosition - Center.transform.localPosition;
        heading_right.y = 0;

        Vector3 heading_left = Left.transform.localPosition - Center.transform.localPosition;
        heading_left.y = 0;

        var R = Vector3.Dot(cam_vector, heading_right);
        var L = Vector3.Dot(cam_vector, heading_left);

        if (R < 0 && L < 0)
        {
            step_move_back();
            state = "Backward";
        }

        else
        {
            step_move_forward();
            state = "Forward";
        }
          
        */

        //--------------------------------------------------------

        Right_before = Right.position.y;
        Left_before = Left.position.y;
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
        if ((Right_after - Right_before > 0.003))
        {

            Vector3 dir1 = camTr.TransformDirection(Vector3.forward);
            dir1.y = 0;
            //transform.LookAt(dir1);

            //transform.rotation = Quaternion.Euler(dir1);
            transform.position += dir1 * Time.deltaTime * movementSpeed;
        }

        if (Left_after - Left_before > 0.003)
        {
            // print("왼발 움직일걸");

            Vector3 dir2 = camTr.TransformDirection(Vector3.forward);
            dir2.y = 0;
            //transform.LookAt(dir2);

            //transform.rotation = Quaternion.Euler(dir2);
            transform.position += dir2 * Time.deltaTime * movementSpeed;
        }
    }

    private void step_move_back()
    {
        if ((Right_after - Right_before > 0.003))
        {
            //print("오른발 움직일걸
            Vector3 dir1 = camTr.TransformDirection(-1 * Vector3.forward);
            dir1.y = 0;
            //transform.LookAt(dir1);

            transform.position += dir1 * Time.deltaTime * movementSpeed;
        }

        if (Left_after - Left_before > 0.003)
        {
            //print("왼발 움직일걸");

            Vector3 dir2 = camTr.TransformDirection(-1 * Vector3.forward);
            dir2.y = 0;
            //transform.LookAt(dir2);

            //transform.rotation = Quaternion.Euler(dir2);
            transform.position += dir2 * Time.deltaTime * movementSpeed;
        }
    }
}
