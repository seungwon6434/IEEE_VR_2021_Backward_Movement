using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;
using UnityEditorInternal;

public class OutsideSecondEvent : MonoBehaviour
{
    public GameObject Bus;

    Animator BusAnimator;

    // Start is called before the first frame update
    void Start()
    {
        BusAnimator = Bus.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "male4")
        {
            
            BusAnimator.SetTrigger("BusFirstStopClose");
            BusAnimator.SetTrigger("BusRight");
            BusAnimator.SetTrigger("BusSecondStopForward");

        }
    }
}
