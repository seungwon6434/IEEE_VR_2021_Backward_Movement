using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class BackOkCheck : MonoBehaviour
{
    public GameObject CardTag;
    public Material Tmoney1;

    public PlayableDirector playableDirector5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            CardTag.GetComponent<MeshRenderer>().material = Tmoney1;
            CardTag.GetComponent<BusSecondEvent>().backtag = true;

            playableDirector5.Play();

            gameObject.SetActive(false);
        }
    }
}
