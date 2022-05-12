using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class SetPositionSync : MonoBehaviour
{
    //public GameObject Camera;
    //public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if ( Input.GetKey(KeyCode.UpArrow) ) 
        {
            print("1");
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            print("2");
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            print("3");
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("4 ");
            transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        }
        
    }
}
