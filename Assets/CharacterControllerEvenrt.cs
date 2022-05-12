using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerEvenrt : MonoBehaviour
{
    public GameObject Player;
    
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
        if (col.tag == "hand")
        {
            Vector3 dir2 = Player.transform.GetChild(2).transform.localRotation * Vector3.right;
            //Vector3 dir2 = Player.transform.GetChild(2).transform.localRotation * Vector3.forward;
            Player.transform.localPosition += dir2 * 0.8f;

            
        }
    }

}