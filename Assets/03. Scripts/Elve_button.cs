using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class Elve_button : MonoBehaviour
{

    public GameObject KATPlayer;
    public GameObject KAT_Player_Camerarig;
    public GameObject ControllerPlayer;
    public GameObject WiPPlyer;
    public GameObject WiPPlyer_Camera;



    public GameObject BackOk1;
    
    public GameObject timeline_4;
    PlayableDirector playableDirector4;

    GameObject Elve;
    Animator animator;
    int touch = 0;
    public bool touched = true;

    void Start() 
    {
        Elve = this.transform.parent.transform.parent.gameObject;
        animator = Elve.GetComponent<Animator>();

        print(animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.1 close"));
        print(this.GetComponent<MeshRenderer>().material.color);

        playableDirector4 = timeline_4.GetComponent<PlayableDirector>();


    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
            print("hand trigger");
            //playableDirector4.Play();

            //var WiP = other.gameObject.transform.parent;
            //WiP.transform.SetParent(Elve.transform);

            KATPlayer.transform.SetParent(Elve.transform);
            ControllerPlayer.transform.SetParent(Elve.transform);
            WiPPlyer.transform.SetParent(Elve.transform);

            if (touch >= 1 && !touched)
            {
                this.GetComponent<MeshRenderer>().material.color = Color.yellow;

                animator.SetTrigger("1 close");
                animator.SetTrigger("1-6");
                animator.SetTrigger("6 open");

            }

            else if (touch ==0 && touched)
            {
                Vector3 dir4 = KAT_Player_Camerarig.transform.GetChild(2).transform.localRotation * Vector3.right;
                KATPlayer.transform.localPosition += dir4 * 0.4f;

                Vector3 dir2 = WiPPlyer_Camera.transform.localRotation * Vector3.right;
                WiPPlyer.transform.localPosition += dir2 * 0.4f;

                Vector3 dir3 = ControllerPlayer.transform.GetChild(2).transform.localRotation * Vector3.right;
                ControllerPlayer.transform.localPosition += dir3 * 0.4f;

                playableDirector4.Play();
                BackOk1.SetActive(true);

                //touched = false;
                touch++;

            }

            else if (touch>=1 && touched) playableDirector4.Play();

        }
    }

}
