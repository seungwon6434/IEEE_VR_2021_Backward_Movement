using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;


public class LibSecondBackCheck : MonoBehaviour
{
    public PlayableDirector playableDirector6;

    public Animator Runner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "hand")
        {
            playableDirector6.Play();
            Runner.SetFloat("MoveFaster", 1);

            gameObject.SetActive(false);
        }
    }
}
