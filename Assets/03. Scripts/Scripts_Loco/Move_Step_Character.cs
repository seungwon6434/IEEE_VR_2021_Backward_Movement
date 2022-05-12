using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Move_Step_Character : MonoBehaviour
{
    public GameObject TCP;
    public CharacterController controller;
    
    private Transform camTr;
    private Transform Left;
    private Transform Right;

    private float Right_before = 0;
    private float Left_before = 0;

    private float Right_after = 0;
    private float Left_after = 0;

    public float movementSpeed;
    private bool trigger = true;

    private Vector3 forback = Vector3.forward;

    public SteamVR_Action_Boolean grabPinch;
    public bool Test;
    public float gravity = -9.81f;
    Vector3 velocity;

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
        Right_after = Right.localPosition.y;
        Left_after = Left.localPosition.y;

        float temp = Right_after - Right_before;

        //var result = TCP.GetComponent<TCPTestClient>().result;

        //print("디렉션 : "+temp_1);

        //---------------------- Test 할때 -------------------------

        if (trigger)
        {
            var temp_1 = TCP.GetComponent<TCPTestClient>().result;

            if (temp_1 == " Forward")
            {
                //print("Forward");
                //state = "Forward";
                step_move_forward();
            }

            else if (temp_1 == " Backward")
            {
                //print("다른 거");
                //state = "Backward";
                step_move_back();
            }
        }

        //---------------------------------------------------
        /*
        else
        {
            if (grabPinch.state == false)
            {
                //state = "Forward";
                step_move_forward();
            }

            else
            {
                //state = "Backward";
                step_move_back();
            }
        }
        */
        
        Right_before = Right.localPosition.y;
        Left_before = Left.localPosition.y;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void step_move_forward()
    {
        if ((Right_after - Right_before > 0.005))
        {
            //print("오른발 움직일걸");

            Vector3 dir1 = camTr.TransformDirection(Vector3.forward);
            dir1.y = 0;

            controller.Move(dir1 * Time.deltaTime* movementSpeed);
        }

        if (Left_after - Left_before > 0.003)
        {
            // print("왼발 움직일걸");

            Vector3 dir2 = camTr.TransformDirection(Vector3.forward);
            dir2.y = 0;
            controller.Move(dir2 * Time.deltaTime * movementSpeed);
        }
    }

    private void step_move_back()
    {
        if ((Right_after - Right_before > 0.003))
        {
            //print("오른발 움직일걸");

            Vector3 dir1 = camTr.TransformDirection(-1 * Vector3.forward);
            dir1.y = 0;
            controller.Move(dir1 * Time.deltaTime * movementSpeed);
        }

        if (Left_after - Left_before > 0.003)
        {
            //print("왼발 움직일걸");

            Vector3 dir2 = camTr.TransformDirection(-1 * Vector3.forward);
            dir2.y = 0;
            controller.Move(dir2 * Time.deltaTime * movementSpeed);
        }
    }
}
