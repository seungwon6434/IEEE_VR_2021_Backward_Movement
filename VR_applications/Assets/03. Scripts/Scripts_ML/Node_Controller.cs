using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Controller : MonoBehaviour
{
    [SerializeField] public int block = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (block == 1) 
        {
            this.gameObject.tag = "block";
            this.GetComponent<MeshRenderer>().material.color = Color.black;
        }

        else if (block ==2)
        {
            this.gameObject.tag = "normal";
            this.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

}




