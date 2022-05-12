using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Events;
using UnityEditorInternal;

public class BackOkCheck2 : MonoBehaviour
{
    public GameObject Bus;
    public PlayableDirector playableDirector8;

    Animator BusAnimator;

    // Start is called before the first frame update
    void Start()
    {
        BusAnimator = Bus.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            playableDirector8.Play();

            BusAnimator.SetFloat("animSpeed", 1f);

            gameObject.SetActive(false);
        }
    }
}
