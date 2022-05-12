using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class ElveDescription : MonoBehaviour
{
    Animator Elve_animator;

    public GameObject ReadyForPeople;
    
    public GameObject timeline_5;
    public GameObject timeline_7;
    public GameObject timeline_8;

    bool timeline1 = false;
    bool timeline2 = false;
    bool timeline3 = false;

    PlayableDirector playableDirector5;
    PlayableDirector playableDirector7;
    PlayableDirector playableDirector8;

    // Start is called before the first frame update
    void Start()
    {
        Elve_animator = this.gameObject.GetComponent<Animator>();
        print(Elve_animator);

        playableDirector5 = timeline_5.GetComponent<PlayableDirector>();
        playableDirector7 = timeline_7.GetComponent<PlayableDirector>();
        playableDirector8 = timeline_8.GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(CheckElve("Base Layer.1-6"));

        if (CheckElve("Base Layer.1-6") && !timeline1) 
        {
            print("check1-6");
            //playableDirector5.Play();

            timeline1 = true;
        }

        if (CheckElve("Base Layer.6-8") && !timeline2)
        {
            //print("check1-6");
            playableDirector7.Play();
            ReadyForPeople.SetActive(true);
            Elve_animator.SetFloat("AnimSpeed", 0);

            timeline2 = true;
        }

        if (CheckElve_complete("Base Layer.9 open") && !timeline3)
        {
            //print("check1-6");
            playableDirector8.Play();

            timeline3 = true;
        }
    }

    private bool CheckElve(string a)
    {
        return Elve_animator.GetCurrentAnimatorStateInfo(0).IsName(a) &&

            Elve_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.70f;

    }

    private bool CheckElve_complete(string a)
    {
        return Elve_animator.GetCurrentAnimatorStateInfo(0).IsName(a) &&

            Elve_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f;

    }
}
