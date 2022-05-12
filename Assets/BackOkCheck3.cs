using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Events;
using UnityEditorInternal;
using UnityEngine.Playables;

public class BackOkCheck3 : MonoBehaviour
{
    public PlayableDirector playableDirector11;
    

    public GameObject button;

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
            playableDirector11.Play();

            button.GetComponent<BusLastEvent>().backok3 = true;

            this.gameObject.SetActive(false);
        }
    }
}
