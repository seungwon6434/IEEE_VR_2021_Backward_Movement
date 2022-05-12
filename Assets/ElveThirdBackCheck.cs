using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class ElveThirdBackCheck : MonoBehaviour
{
    public PlayableDirector playableDirector7_1;
    public Animator Elve;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Elve.SetFloat("AnimSpeed", 1);
            
            playableDirector7_1.Play();

            gameObject.SetActive(false);
        }
    }
}
