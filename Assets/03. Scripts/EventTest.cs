using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EventTest : MonoBehaviour
{

    public UnityEvent FirstDescription;

    private void Event()
    {
        FirstDescription.Invoke();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //print("from event trigger");
            Event();
        }
    }
}
