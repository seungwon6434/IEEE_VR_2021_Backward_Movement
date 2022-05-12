using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GetHeadOrientation : MonoBehaviour
{
    public GameObject Player_Contorller_Camera;
   // public GameObject Player_WiP_Camera;
   // public GameObject Player_KAT_Camerarig;

    public StreamWriter textWrite;

    // Start is called before the first frame update
    void Start()
    {
        var s1 = System.DateTime.Now.ToString("HH_mm_ss_FF");

        string textFile = @"C:\Users\AjouHCI\Desktop\Event_Test\" + s1 + gameObject.name.ToString() + SceneManager.GetActiveScene().name + "_HeadPos.txt";
        textWrite = File.CreateText(textFile);

        //textWrite.WriteLine(gameObject.name.ToString() + " " + s1);

        textWrite.WriteLine("Date, Time, Head_pos.x, Head_pos.y, Head_pos.z, Head_rot.x, Head_rot.y, Head_rot.z");

    }

    // Update is called once per frame
    void Update()
    {
        string s1 = System.DateTime.Now.ToString("yyyyMMdd");
        string s2 = System.DateTime.Now.ToString("HH:mm:ss");

        var pos_xh = Player_Contorller_Camera.transform.position.x;
        var pos_yh = Player_Contorller_Camera.transform.position.y;
        var pos_zh = Player_Contorller_Camera.transform.position.z;

        var rot_xh = Player_Contorller_Camera.transform.rotation.x;
        var rot_yh = Player_Contorller_Camera.transform.rotation.y;
        var rot_zh = Player_Contorller_Camera.transform.rotation.z;

        string a = s1 + ", " + s2 + ", "
                    + pos_xh.ToString() + ", " + pos_yh.ToString() + ", " + pos_zh.ToString() + ", "
                    + rot_xh.ToString() + ", " + rot_yh.ToString() + ", " + rot_zh.ToString();

        //textWrite.WriteLine(a);
    }
}
