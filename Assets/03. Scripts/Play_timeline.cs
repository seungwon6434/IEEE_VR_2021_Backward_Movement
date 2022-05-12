using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class Play_timeline : MonoBehaviour
{

    //public UnityEvent FirstDescription;

    PlayableDirector playableDirector1;
    PlayableDirector playableDirector2;
    PlayableDirector playableDirector3;

    PlayableDirector playableDirector6;
    public PlayableDirector playableDirector6_1;
    PlayableDirector playableDirector8;

    public GameObject timeline_1;
    public GameObject timeline_2;
    public GameObject timeline_3;

    public GameObject timeline_6;
    public GameObject timeline_8;

    public GameObject close_door;

    public Animator elve_animator;

    void Start()
    {
        playableDirector1 = timeline_1.GetComponent<PlayableDirector>();
        playableDirector2 = timeline_2.GetComponent<PlayableDirector>();
        playableDirector3 = timeline_3.GetComponent<PlayableDirector>();

        playableDirector6 = timeline_6.GetComponent<PlayableDirector>();
        playableDirector8 = timeline_8.GetComponent<PlayableDirector>();

        playableDirector1.Play();
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "first") 
        {
            print("first");
            playableDirector2.Play();
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
        }

        if (col.tag == "second")
        {
            playableDirector3.Play();
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
        }

        if (col.tag == "sixth")
        {
            playableDirector6.Play();
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);

            close_door.SetActive(true);
        }

        if (col.tag == "close_door")
        {
            playableDirector6_1.Play();
            col.gameObject.SetActive(false);

            elve_animator.SetTrigger("6 close");
            elve_animator.SetTrigger("6-8");
            elve_animator.SetTrigger("8 open");

        }

        if (col.tag == "eighth")
        {
            //playableDirector6.Play();
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);

            playableDirector8.Play();

        }

    }

    

}
