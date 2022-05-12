using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;


public class BusFirstEvent : MonoBehaviour
{
    public GameObject Bus;
    public PlayableDirector playableDirector1;

    Animator BusAnimator;




    // Start is called before the first frame update
    void Start()
    {
        BusAnimator = Bus.GetComponent<Animator>();
    }

    
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            BusAnimator.SetTrigger("BusArrive");
            BusAnimator.SetTrigger("BusOpenDoor");

            this.gameObject.SetActive(false);
        }
    }
}
