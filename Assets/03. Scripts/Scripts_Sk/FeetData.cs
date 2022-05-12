using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Diagnostics;
using System;
using UnityEngine.UI;

public class FeetData : MonoBehaviour
{
    public GameObject Head;
    public GameObject Waist;
    public GameObject RightFoot;
    public GameObject LeftFoot;
    public GameObject Center;

    public StreamWriter textWrite;

    Stopwatch Timer;
    double total_timer;

    public string data;

    // Start is called before the first frame update
    void Start()
    {
        string s3 = System.DateTime.Now.ToString("HH_mm_ss");
        Timer = new Stopwatch();

        //string textFile = @"C:\Users\AjouHCI\Desktop\Event_Test\" + s3 + "_backward11.txt";

        //textWrite = File.CreateText(textFile);
        //textWrite.WriteLine("Date, Time , Timer, Right_pos.x, Right_pos.y, Right_pos.z, Right_rot.x, Right_rot.y, Right_rot.z, Left_pos.x, Left_pos.y, Left_pos.z, Left_rot.x, Left_rot.y, Left_rot.z, Head_pos.x, Head_pos.y, Head_pos.z, Head_rot.x, Head_rot.y, Head_rot.z, Waist_pos.x, Waist_pos.y, Waist_pos.z, Waist_rot.x, Waist_rot.y, Waist_rot.z, Direction");
    }

    // Update is called once per frame
    void Update()
    {
        Timer.Start();
        
    }

    private void FixedUpdate()
    {
        var temp = Timer.Elapsed.TotalSeconds;
        total_timer = Math.Truncate(temp * 100) / 100;

        var str = "state";
        var str1 = total_timer.ToString();

        string s1 = System.DateTime.Now.ToString("yyyyMMdd");
        string s2 = System.DateTime.Now.ToString("HH:mm:ss");

        Vector3 cam_vector = Head.transform.TransformDirection(Vector3.forward) - Center.transform.localPosition;
        cam_vector.y = 0;

        Vector3 heading_right = RightFoot.transform.localPosition - Center.transform.localPosition;
        heading_right.y = 0;

        Vector3 heading_left = LeftFoot.transform.localPosition - Center.transform.localPosition;
        heading_left.y = 0;

        var RightPos_x = heading_right.x;
        var RightPos_y = Vector3.Dot(cam_vector, heading_right);
        var RightPos_z = heading_right.z;

        var RightRot_x = RightFoot.transform.rotation.x;
        var RightRot_y = RightFoot.transform.rotation.y;
        var RightRot_z = RightFoot.transform.rotation.z;

        var LeftPos_x = heading_left.x;
        var LeftPos_y = Vector3.Dot(cam_vector, heading_left);
        var LeftPos_z = heading_left.z;

        var LeftRot_x = LeftFoot.transform.rotation.x;
        var LeftRot_y = LeftFoot.transform.rotation.y;
        var LeftRot_z = LeftFoot.transform.rotation.z;

        var HeadPos_x = Head.transform.localPosition.x;
        var HeadPos_y = Head.transform.localPosition.y;
        var HeadPos_z = Head.transform.localPosition.z;

        var HeadRot_x = Head.transform.rotation.x;
        var HeadRot_y = Head.transform.rotation.y;
        var HeadRot_z = Head.transform.rotation.z;

        var WaistPos_x = Waist.transform.localPosition.x;
        var WaistPos_y = Waist.transform.localPosition.y;
        var WaistPos_z = Waist.transform.localPosition.z;

        var WaistRot_x = Waist.transform.rotation.x;
        var WaistRot_y = Waist.transform.rotation.y;
        var WaistRot_z = Waist.transform.rotation.z;

        string a = s1 + ", " + s2 + ", " + str1.ToString() + ", "
                    + RightPos_x.ToString() + ", " + RightPos_y.ToString() + ", " + RightPos_z.ToString() + ", "
                    + RightRot_x.ToString() + ", " + RightRot_y.ToString() + ", " + RightRot_z.ToString() + ", "
                    + LeftPos_x.ToString() + ", " + LeftPos_y.ToString() + ", " + LeftPos_z.ToString() + ", "
                    + LeftRot_x.ToString() + ", " + LeftRot_y.ToString() + ", " + LeftRot_z.ToString() + ", "
                    + HeadPos_x.ToString() + ", " + HeadPos_y.ToString() + ", " + HeadPos_z.ToString() + ", "
                    + HeadRot_x.ToString() + ", " + HeadRot_y.ToString() + ", " + HeadRot_z.ToString() + ", "
                    + WaistPos_x.ToString() + ", " + WaistPos_y.ToString() + ", " + WaistPos_z.ToString() + ", "
                    + WaistRot_x.ToString() + ", " + WaistRot_y.ToString() + ", " + WaistRot_z.ToString() + ", "
                  + str;

        data = a;

        //textWrite.WriteLine(data);
    }
}
