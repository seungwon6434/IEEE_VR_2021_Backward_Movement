using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock_On : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("clock").GetComponent<Clock>().enabled = true;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
