using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{

    bool IsPause;

    GameObject pause;

    //public UnityEvent FirstDescription;

    // Use this for initialization
    void Start()
    {
        IsPause = false;
        pause = transform.GetChild(0).gameObject;

        //PauseScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PauseScene();
        }
    }

    void OnEnable()
    {
        //PauseScene();
    }

    public void PauseScene()
    {
        //tprint("씬 정지");

        print(IsPause);

        /*일시정지 활성화*/
        if (IsPause == false)
        {
            Time.timeScale = 0;
            IsPause = true;
            pause.SetActive(true);
            return;
        }

        /*일시정지 비활성화*/
        if (IsPause == true)
        {
            Time.timeScale = 1;
            IsPause = false;
            pause.SetActive(false);
            return;
        }
    }

    void OnDisable()
    {
        //PauseScene();
    }

    void OnDestroy()
    {
        //PauseScene();
    }
}


