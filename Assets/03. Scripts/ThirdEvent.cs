using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class ThirdEvent : MonoBehaviour
{
    public GameObject BackOk3;

    public GameObject WiP;
    public GameObject WiP_cam;



    public PlayableDirector playableDirector7;
    public PlayableDirector playableDirector9;

    int touch = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
           

            if (touch >= 1)
            {
                this.GetComponent<MeshRenderer>().material.color = Color.yellow;
                
                playableDirector9.Play();



            }

            else
            {
                Vector3 dir2 = WiP_cam.transform.TransformDirection(Vector3.forward);

                WiP.transform.localPosition += dir2 * 0.5f;


                touch++;

                playableDirector7.Play();

                BackOk3.SetActive(true);

}
        }
    }
}
