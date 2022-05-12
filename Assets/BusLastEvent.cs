using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;
using UnityEditorInternal;

public class BusLastEvent : MonoBehaviour
{
    public GameObject Bus;
    
    public GameObject Player;
    public GameObject Player_Cam;
    public GameObject Contorller_Player;
    public GameObject KAT_Player;
    public GameObject KAT_Player_Camera;
    public GameObject Panel;

    public GameObject BackOk3;

    public PlayableDirector playableDirector9;
    public PlayableDirector playableDirector10;
    public PlayableDirector playableDirector12;

    Animator BusAnimator;

    bool play9 = true;
    public bool backok3 = false;

    int tagtime = 0;

    // Start is called before the first frame update
    void Start()
    {
        BusAnimator = Bus.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckBus_complete_fifty("Base Layer.BusSecondStopForward") && play9)
        {
            GetComponent<Outline>().enabled = true;
            GetComponent<SphereCollider>().enabled = true;

            BusAnimator.SetTrigger("BusSecondStopOpen");
            playableDirector9.Play();
            BusAnimator.SetFloat("animSpeed", 0f);

            play9 = false;
        }
    }

    private bool CheckBus_complete_fifty(string a)
    {
        return BusAnimator.GetCurrentAnimatorStateInfo(0).IsName(a) &&

            BusAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f;

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "hand")
        {
            if (tagtime == 0 && !backok3)
            {
                Vector3 dir2 = Player_Cam.transform.localRotation * Vector3.right;
                Player.transform.localPosition += dir2 * 0.3f;

                Vector3 dir3 = Contorller_Player.transform.GetChild(2).transform.localRotation * Vector3.right;
                Contorller_Player.transform.localPosition += dir3 * 0.3f;

                Vector3 dir4 = KAT_Player_Camera.transform.GetChild(2).transform.localRotation * Vector3.right;
                KAT_Player.transform.localPosition += dir4 * 0.3f;

                playableDirector10.Play();
                tagtime++;

                BackOk3.SetActive(true);
                Panel.SetActive(false);
            }

            
            else if (tagtime >= 1 && backok3)
            {
                playableDirector12.Play();
                BusAnimator.SetFloat("animSpeed", 1f);
                tagtime++;
            }
            


        }
    }
}
