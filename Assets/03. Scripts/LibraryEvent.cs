using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class LibraryEvent : MonoBehaviour
{
    public GameObject Wall;

    public GameObject book1;
    public GameObject book2;

    public GameObject BackCheck1;
    public GameObject BackCheck2;
    public GameObject BackCheck3;

    public PlayableDirector playableDirector1;
    public PlayableDirector playableDirector2;

    public PlayableDirector playableDirector4;


    // Start is called before the first frame update
    void Start()
    {
        playableDirector1.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "first")
        {
            col.gameObject.SetActive(false);
            Wall.SetActive(true);
        }

        if (col.tag == "firsttrigger")
        {
            col.gameObject.SetActive(false);
            playableDirector2.Play();
            BackCheck1.SetActive(true);
        }

        if (col.tag == "second")
        {
            col.gameObject.SetActive(false);
            playableDirector4.Play();

            book1.GetComponent<Outlineblink>().enabled = true;
            book2.GetComponent<Outlineblink>().enabled = true;
        }
    }
}
