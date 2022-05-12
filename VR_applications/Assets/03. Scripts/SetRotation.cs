using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{

    public GameObject Cam;

    void Start()
    {

    }

    void Update()
    {
        //transform.rotation = Cam.transform.rotation;

        transform.eulerAngles = new Vector3(0, Cam.transform.rotation.eulerAngles.y, 0);
            //Cam.transform.rotation.eulerAngles

    }


}

