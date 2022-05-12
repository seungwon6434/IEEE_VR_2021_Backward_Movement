using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class LibThirdBackCheck : MonoBehaviour
{
    public PlayableDirector playableDirector8;



    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            playableDirector8.Play();
           

            gameObject.SetActive(false);
        }
    }

}