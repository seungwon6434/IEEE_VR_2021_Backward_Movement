using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;
using UnityEditorInternal;

public class BusThirdEvent : MonoBehaviour
{
    public GameObject Player;
    public GameObject Controller_Player;
    public GameObject KAT_Player;

    public GameObject Bus;
    public GameObject StopGuy;

    public GameObject BackOk;

    public PlayableDirector playableDirector7;
    public PlayableDirector playableDirector_person;

    Animator BusAnimator;
    Animator GuyAnimator;
    bool play7 = true;

    // Start is called before the first frame update
    void Start()
    {
        BusAnimator = Bus.GetComponent<Animator>();
        GuyAnimator = StopGuy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckBus_complete_seventy("Base Layer.BusMoveForward") && play7)
        {
            playableDirector7.Play();
            BusAnimator.SetFloat("animSpeed", 0f);
            BackOk.SetActive(true);

            play7 = false;
            BusAnimator.SetTrigger("BusFirstStopOpen");
        }

        if (CheckBus_complete("Base Layer.BusMoveForward"))
        {
            //지워야함


            playableDirector_person.Play();
            GuyAnimator.SetTrigger("WalkingStandard");



        }


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Player.transform.SetParent(Bus.transform);
            Controller_Player.transform.SetParent(Bus.transform);
            KAT_Player.transform.SetParent(Bus.transform);

            BusAnimator.SetTrigger("BusForward");

        }
    }

    private bool CheckBus_complete_seventy(string a)
    {
        return BusAnimator.GetCurrentAnimatorStateInfo(0).IsName(a) &&

            BusAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f;

    }

    private bool CheckBus_complete(string a)
    {
        return BusAnimator.GetCurrentAnimatorStateInfo(0).IsName(a) &&

            BusAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f;

    }
}
