using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionTest : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 dir2 = Player.transform.GetChild(2).transform.localRotation * Vector3.right;
            Player.transform.localPosition += dir2 * 0.3f;
        }
        
    }
}
