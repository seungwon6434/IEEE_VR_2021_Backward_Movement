using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Only_for_Trigger_ML : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("for 트리거");
;    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        /*

        if (other.CompareTag("normal"))
        {
            print("팔로워의 노드방문");
        }

        else if (other.CompareTag("end"))
        {
            print("엔드 트리거_트리거 온리");
            //setTarget(true);
        }

        else if (other.CompareTag("start"))
        {

        }
        */
    }
}
