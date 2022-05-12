using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System.IO;

public class Find_Index : MonoBehaviour
{
    GameObject Left;
    GameObject Right;

    public StreamWriter textWrite;
    public StreamWriter textWrite_l;

   

    public string sensors;

    
   public GameObject ControllerRight;
   public GameObject ControllerLeft;
   public GameObject ControllerHead;
   public GameObject ControllerWaist;
   public GameObject Center;


    // Start is called before the first frame update
    void Start()
    {
        string s3 = System.DateTime.Now.ToString("HH_mm_ss");

        uint index = 0;
        var error = ETrackedPropertyError.TrackedProp_Success;

        for (uint i = 0; i < 16; i++)
        {
            var result = new System.Text.StringBuilder((int)64);
            OpenVR.System.GetStringTrackedDeviceProperty(i, ETrackedDeviceProperty.Prop_RenderModelName_String, result, 64, ref error);

            if (result.ToString().Contains("tracker"))
            {
                index = i;
                print(i);
                print(result.ToString());

            }
        }

        //print(s3);
        string textFile = @"C:\Users\AjouHCI\Desktop\text\"+ s3 +"_backward.txt";
        //string textFile = @"C:\Users\AjouHCI\Desktop\text\1030_backward.txt";

        //string textFile_l = @"C:\Users\Seungwon\Desktop\0408_PathFind\text\2020_0507_SW_left_back.txt";
        //string copyFile = @"C:\test\copy.txt";

        textWrite = File.CreateText(textFile); //생성
        //textWrite_l = File.CreateText(textFile_l);

        textWrite.WriteLine("Date, Time , Timer, Right_pos.x, Right_pos.y, Right_pos.z, Right_rot.x, Right_rot.y, Right_rot.z, Left_pos.x, Left_pos.y, Left_pos.z, Left_rot.x, Left_rot.y, Left_rot.z, Head_pos.x, Head_pos.y, Head_pos.z, Head_rot.x, Head_rot.y, Head_rot.z, Waist_pos.x, Waist_pos.y, Waist_pos.z, Waist_rot.x, Waist_rot.y, Waist_rot.z, Direction");
        //textWrite_l.WriteLine("Date, Time , pos.x, pos.y, pos.z, rot.x, rot.y, rot.z");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        

        //GameObject temp = GameObject.Find("New_Player");
        GameObject temp = GameObject.Find("Walking_Player");
        var str = temp.GetComponent<Move_step>().state;

        GameObject temp1 = GameObject.Find("Timer");
        var str1 = temp1.GetComponent<GetTimer>().total_timer;

        string s1 = System.DateTime.Now.ToString("yyyyMMdd");
        string s2 = System.DateTime.Now.ToString("HH:mm:ss");

        Vector3 cam_vector = ControllerHead.transform.TransformDirection(Vector3.forward) - Center.transform.localPosition;
        cam_vector.y = 0;

        Vector3 heading_right = ControllerRight.transform.localPosition - Center.transform.localPosition;
        heading_right.y = 0;

        Vector3 heading_left = ControllerLeft.transform.localPosition - Center.transform.localPosition;
        heading_left.y = 0;



        var pos_x = heading_right.x;
        var pos_y = Vector3.Dot(cam_vector, heading_right);
        var pos_z = heading_right.z;

        var rot_x = ControllerRight.transform.rotation.x;
        var rot_y = ControllerRight.transform.rotation.y;
        var rot_z = ControllerRight.transform.rotation.z;

        var pos_xl = heading_left.x;
        var pos_yl = Vector3.Dot(cam_vector, heading_left);
        var pos_zl = heading_left.z;

        var rot_xl = ControllerLeft.transform.rotation.x;
        var rot_yl = ControllerLeft.transform.rotation.y;
        var rot_zl = ControllerLeft.transform.rotation.z;

        var pos_xh = ControllerHead.transform.localPosition.x;
        var pos_yh = ControllerHead.transform.localPosition.y;
        var pos_zh = ControllerHead.transform.localPosition.z;

        var rot_xh = ControllerHead.transform.rotation.x;
        var rot_yh = ControllerHead.transform.rotation.y;
        var rot_zh = ControllerHead.transform.rotation.z;

        var pos_xw = ControllerWaist.transform.localPosition.x;
        var pos_yw = ControllerWaist.transform.localPosition.y;
        var pos_zw = ControllerWaist.transform.localPosition.z;

        var rot_xw = ControllerWaist.transform.rotation.x;
        var rot_yw = ControllerWaist.transform.rotation.y;
        var rot_zw = ControllerWaist.transform.rotation.z;

        string a = s1 + ", " + s2 + ", " + str1.ToString() + ", "
                    + pos_x.ToString() + ", " + pos_y.ToString() + ", " + pos_z.ToString() + ", "
                    + rot_x.ToString() + ", " + rot_y.ToString() + ", " + rot_z.ToString() + ", "
                    + pos_xl.ToString() + ", " + pos_yl.ToString() + ", " + pos_zl.ToString() + ", "
                    + rot_xl.ToString() + ", " + rot_yl.ToString() + ", " + rot_zl.ToString() + ", "
                    + pos_xh.ToString() + ", " + pos_yh.ToString() + ", " + pos_zh.ToString() + ", "
                    + rot_xh.ToString() + ", " + rot_yh.ToString() + ", " + rot_zh.ToString() + ", "
                    + pos_xw.ToString() + ", " + pos_yw.ToString() + ", " + pos_zw.ToString() + ", "
                    + rot_xw.ToString() + ", " + rot_yw.ToString() + ", " + rot_zw.ToString() + ", "
                    + str; 
                  

       
        sensors = a;

        //print(a);

        //string a = "sss";
        //string b = s1 + ", " + s2 + ", " + pos_xl.ToString() + ", " + pos_yl.ToString() + ", " + pos_zl.ToString() + ", " + rot_xl.ToString() + ", " + rot_yl.ToString() + ", " + rot_zl.ToString();
        //print(sensors);
        textWrite.WriteLine(sensors); //쓰기s
        //textWrite_l.WriteLine(b);
    }

    void OnDestroy() 
    {
        textWrite.Dispose(); //파일 닫기
    }



}
