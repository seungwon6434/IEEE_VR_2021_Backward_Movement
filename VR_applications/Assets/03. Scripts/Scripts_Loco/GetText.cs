using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

using System;
using UnityEngine.UI;

public class GetText : MonoBehaviour
{
    private Text direction;
    

    
    // Start is called before the first frame update
    void Start()
    {
        direction = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject temp = GameObject.Find("New_Player");
        GameObject temp = GameObject.Find("Walking_Player");
        var str = temp.GetComponent<Move_step>().state;

        //print(str);

        direction.text = str;
        
    }
}
