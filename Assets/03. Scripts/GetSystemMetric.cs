using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System.IO;
using UnityEngine.SceneManagement;


public class GetSystemMetric : MonoBehaviour
{
    public GameObject Player_Contorller;
    public GameObject Player_WiP;
    public GameObject Player_KAT;

    public StreamWriter textWrite;


    bool a = false;
    bool b = false;
    bool c = false;


    // Start is called before the first frame update
    void Start()
    {
        var s1 = System.DateTime.Now.ToString("HH:mm:ss:FF");
        var s2 = System.DateTime.Now.ToString("HH_mm_ss_FF");
        print(s2);

        Player_Contorller.transform.hasChanged = false;
        Player_WiP.transform.hasChanged = false;
        Player_KAT.transform.hasChanged = false;

        string textFile = @"C:\Users\AjouHCI\Desktop\Event_Test\" + s2 + gameObject.name.ToString() + SceneManager.GetActiveScene().name + "_event.txt";
        textWrite = File.CreateText(textFile);

        textWrite.WriteLine(gameObject.name.ToString()+ " " + s1);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Contorller.transform.hasChanged && !a)
        {
            var s2 = System.DateTime.Now.ToString("HH:mm:ss:FF"); a = true;
            print(s2);
            textWrite.WriteLine(gameObject.name.ToString() + "Controller" + s2);
            //textWrite.Dispose();
        }

        if (Player_WiP.transform.hasChanged && !b)
        {
            var s2 = System.DateTime.Now.ToString("HH:mm:ss:FF"); b = true;
            print(s2);
            textWrite.WriteLine(gameObject.name.ToString() + "WiP" + s2);
            //textWrite.Dispose();
        }

        if (Player_KAT.transform.hasChanged && !c)
        {
            var s2 = System.DateTime.Now.ToString("HH:mm:ss:FF"); c = true;
            print(s2);
            textWrite.WriteLine(gameObject.name.ToString() + "KAT" + s2);
            //textWrite.Dispose();
        }
    }

    void OnDestroy()
    {
        
        textWrite.Dispose();
    }

}
