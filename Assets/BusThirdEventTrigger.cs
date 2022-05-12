using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;
using UnityEditorInternal;

public class BusThirdEventTrigger : MonoBehaviour
{
    public PlayableDirector playableDirector6;
    public GameObject OutlineStand;

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            playableDirector6.Play();
            OutlineStand.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
