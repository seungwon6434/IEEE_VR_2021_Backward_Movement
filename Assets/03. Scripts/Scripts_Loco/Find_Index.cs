using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System.IO;

public class Find_Index : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;

    public StreamWriter textWrite;
    public StreamWriter textWrite_l;

    public string sensors;

    // Start is called before the first frame update
    void Start()
    {
        uint index = 0;
        var error = ETrackedPropertyError.TrackedProp_Success;

        for (uint i = 0; i < 16; i++)
        {
            var result = new System.Text.StringBuilder((int)64);
            OpenVR.System.GetStringTrackedDeviceProperty(i, ETrackedDeviceProperty.Prop_RenderModelName_String, result, 64, ref error);

            // print(i);
            // print(result.ToString());

            if (result.ToString().Contains("tracker"))
            {
                index = i;
                print(i);
                print(result.ToString());

                //GameObject ControllerRight = GameObject.Find("Rightfoot");
                //ControllerRight.GetComponent<SteamVR_TrackedObject>().index = (SteamVR_TrackedObject.EIndex)index;
                //break;
            }
        }

        string textFile = @"C:\Users\Seungwon\Desktop\text\2020_0603_SW_1.txt";
        //string textFile_l = @"C:\Users\Seungwon\Desktop\0408_PathFind\text\2020_0507_SW_left_back.txt";
        //string copyFile = @"C:\test\copy.txt";

        textWrite = File.CreateText(textFile); //생성
        //textWrite_l = File.CreateText(textFile_l);

        textWrite.WriteLine("Date, Time , Timer,  Right_pos.x, Right_pos.y, Right_pos.z, Right_rot.x, Right_rot.y, Right_rot.z, Left_pos.x, Left_pos.y, Left_pos.z, Left_rot.x, Left_rot.y, Left_rot.z, Head_pos.x, Head_pos.y, Head_pos.z, Head_rot.x, Head_rot.y, Head_rot.z, Direction, Waist_pos.x, Waist_pos.y, Waist_pos.z, Waist_rot.x, Waist_rot.y, Waist_rot.z,");
        //textWrite_l.WriteLine("Date, Time , pos.x, pos.y, pos.z, rot.x, rot.y, rot.z");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GameObject ControllerRight = GameObject.Find("Rightfoot");
        GameObject ControllerLeft = GameObject.Find("Leftfoot");
        GameObject ControllerHead = GameObject.Find("Head");
        GameObject ControllerWaist = GameObject.Find("Waist");

        GameObject temp = GameObject.Find("[CameraRig]");
        var str = temp.GetComponent<Move_step>().state;

        GameObject temp1 = GameObject.Find("Timer");
        var str1 = temp1.GetComponent<GetTimer>().total_timer;

        string s1 = System.DateTime.Now.ToString("yyyyMMdd");
        string s2 = System.DateTime.Now.ToString("HH:mm:ss");

        var pos_x = ControllerRight.transform.position.x;
        var pos_y = ControllerRight.transform.position.y;
        var pos_z = ControllerRight.transform.position.z;

        var rot_x = ControllerRight.transform.rotation.x;
        var rot_y = ControllerRight.transform.rotation.y;
        var rot_z = ControllerRight.transform.rotation.z;

        var pos_xl = ControllerLeft.transform.position.x;
        var pos_yl = ControllerLeft.transform.position.y;
        var pos_zl = ControllerLeft.transform.position.z;

        var rot_xl = ControllerLeft.transform.rotation.x;
        var rot_yl = ControllerLeft.transform.rotation.y;
        var rot_zl = ControllerLeft.transform.rotation.z;

        var pos_xh = ControllerHead.transform.position.x;
        var pos_yh = ControllerHead.transform.position.y;
        var pos_zh = ControllerHead.transform.position.z;

        var rot_xh = ControllerHead.transform.rotation.x;
        var rot_yh = ControllerHead.transform.rotation.y;
        var rot_zh = ControllerHead.transform.rotation.z;

        //var pos_xw = ControllerWaist.transform.rotation.x;
        //var pos_yw = ControllerWaist.transform.rotation.y;
        //var pos_zw = ControllerWaist.transform.rotation.z;

        //var rot_xw = ControllerWaist.transform.rotation.x;
        //var rot_yw = ControllerWaist.transform.rotation.y;
        //var rot_zw = ControllerWaist.transform.rotation.z;

        string a = s1 + ", " + s2 + ", " + str1.ToString() + ", "
                    + pos_x.ToString() + ", " + pos_y.ToString() + ", " + pos_z.ToString() + ", "
                    + rot_x.ToString() + ", " + rot_y.ToString() + ", " + rot_z.ToString() + ", "
                    + pos_xl.ToString() + ", " + pos_yl.ToString() + ", " + pos_zl.ToString() + ", "
                    + rot_xl.ToString() + ", " + rot_yl.ToString() + ", " + rot_zl.ToString() + ", "
                    + pos_xh.ToString() + ", " + pos_yh.ToString() + ", " + pos_zh.ToString() + ", "
                    + rot_xh.ToString() + ", " + rot_yh.ToString() + ", " + rot_zh.ToString() + ", "
                  + str;

        // + ", "  + pos_xw.ToString() + ", " + pos_yw.ToString() + ", " + pos_zw.ToString() + ", "
        // + rot_xw.ToString() + ", " + rot_yw.ToString() + ", " + rot_zw.ToString() ;

        sensors = a;

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
