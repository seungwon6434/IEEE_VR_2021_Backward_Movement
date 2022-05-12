using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GrabOrNot : MonoBehaviour
{
    public GameObject Warning;

    void Start()
    {
        

    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("target"))
            Warning.SetActive(true);
        else
            Warning.SetActive(false);
    }
    

    public void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("target"))
        {
            Warning.SetActive(true);
        }

    }

    public void OnTriggerExit(Collider other)
    {
            Warning.SetActive(true); 
    }


}
