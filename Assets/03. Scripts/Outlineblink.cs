using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlineblink : MonoBehaviour
{
    float timer;
    int waitingTime;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0; ;
        waitingTime = 1;
        //inside = false;

        this.gameObject.GetComponent<Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (i < 3)
        {
            if (timer > waitingTime)
            {
                //print(i);
                this.gameObject.GetComponent<Outline>().enabled = true;
                //Action
                if (timer > 2 * waitingTime)
                {
                    this.gameObject.GetComponent<Outline>().enabled = false;
                    timer = 0;
                    i++;

                }
            }
        }

        this.gameObject.GetComponent<Outline>().enabled = true;


    }

   

}
