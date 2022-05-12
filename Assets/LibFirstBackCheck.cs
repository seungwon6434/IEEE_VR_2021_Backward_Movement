using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class LibFirstBackCheck : MonoBehaviour
{
    public PlayableDirector playableDirector3;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            playableDirector3.Play();
            gameObject.SetActive(false);
        }
    }
}
