using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System.IO;
using UnityEngine.SceneManagement;


public class GetSystemMetricEnd : MonoBehaviour
{
    public StreamWriter textWrite;

    // Start is called before the first frame update
    void Start()
    {
        var s1 = System.DateTime.Now.ToString("HH:mm:ss:FF");
        var s2 = System.DateTime.Now.ToString("HH_mm_ss_FF");
        print(s2);

        string textFile = @"C:\Users\AjouHCI\Desktop\Event_Test\" + s2 + gameObject.name.ToString()+ SceneManager.GetActiveScene().name + "_Endevent.txt";
        textWrite = File.CreateText(textFile);

        textWrite.WriteLine(gameObject.name.ToString() + " " + s1);

        gameObject.SetActive(false);
    }



    void OnDestroy()
    {
        textWrite.Dispose(); //파일 닫기
    }
}
