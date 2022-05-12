using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;
using UnityEditorInternal;

public class BusSecondEvent : MonoBehaviour
{
    public GameObject Bus;
    public GameObject BackOk;

    public Animator DriverAnimator;

    public Material Tmoney1;
    public Material Tmoney2;
    public Material Tmoney3;

    public PlayableDirector playableDirector2;
    public PlayableDirector playableDirector3;
    public PlayableDirector playableDirector4;

    //public PlayableDirector playableDirector6;

    Animator BusAnimator;

    int tagtime = 0;
    public bool backtag = false;


    void Start()
    {
        BusAnimator = Bus.GetComponent<Animator>();

        GetComponent<MeshRenderer>().material = Tmoney1;


    }

    void Update()
    {
        if (CheckBus_complete("Base Layer.BusOpenDoor"))
        {
            playableDirector2.Play();
        }



    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "hand")
        {
            if (tagtime == 0)
            {
                GetComponent<MeshRenderer>().material = Tmoney3;
                DriverAnimator.SetTrigger("SaySomething");
                BackOk.SetActive(true);

                playableDirector3.Play();
                tagtime++;
            }

            // Cardtag 상황 끝나는 부분
            else if (tagtime == 1 && backtag)
            {
                backtag = false;
                tagtime = 10;

                GetComponent<MeshRenderer>().material = Tmoney2;
                DriverAnimator.SetTrigger("Driving");

                playableDirector4.Play();

                BusAnimator.SetTrigger("BusCloseDoor");
                //BusAnimator.SetTrigger("BusForward");



                //playableDirector6.Play();

            }

            else if (tagtime == 1 && !backtag)
                playableDirector3.Play();


        }

        if (col.tag == "backok")
        {
            GetComponent<MeshRenderer>().material = Tmoney1;
            backtag = true;
            BackOk.SetActive(false);
        }
    }

    private bool CheckBus_complete(string a)
    {
        return BusAnimator.GetCurrentAnimatorStateInfo(0).IsName(a) &&

            BusAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f;

    }
}
