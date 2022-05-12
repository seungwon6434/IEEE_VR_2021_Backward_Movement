using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition_2 : MonoBehaviour
{
    public Transform HMD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = HMD.position;
    }
}
