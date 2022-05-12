using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class ElveFirstBackCheck : MonoBehaviour
{
    public GameObject Button;

    public PlayableDirector playableDirector4_1;
    public void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {

            playableDirector4_1.Play();
            Button.GetComponent<Elve_button>().touched = false;

            gameObject.SetActive(false);
        }
    }
}
