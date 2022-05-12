using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class LibSecondTrigger : MonoBehaviour
{
    public PlayableDirector playableDirector5;

    public GameObject runner;
    public GameObject BackOk2;

    Animator RunnerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        RunnerAnimator = runner.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "hand")
        {
            playableDirector5.Play();
            gameObject.SetActive(false);

            BackOk2.SetActive(true);

            runner.SetActive(true);
            RunnerAnimator.SetFloat("MoveFaster", 0);
        }
    }
}
