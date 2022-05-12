using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSystemMetricMid : MonoBehaviour
{
    public GameObject Player_Contorller;
    public GameObject Player_WiP;
    public GameObject Player_KAT;

    bool a = false;
    bool b = false;
    bool c = false;



    // Start is called before the first frame update
    void Start()
    {
        var s2 = System.DateTime.Now.ToString("HH:mm:ss:FF");
        print(s2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Contorller.transform.hasChanged && !a)
        {

        }

        if (Player_WiP.transform.hasChanged && !b)
        {

        }

        if (Player_KAT.transform.hasChanged && !c)
        {

        }
    }
}
