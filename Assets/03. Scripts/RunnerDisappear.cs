using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerDisappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("runnerdisappear");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) 
    {
        print(col);

        if (col.tag == "third") 
        {
            this.gameObject.SetActive(false);
        }
    }
}
