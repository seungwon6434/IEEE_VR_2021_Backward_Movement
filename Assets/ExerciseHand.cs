using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseHand : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
       
            print("-----------------");
            
            Vector3 dir2 = Player.transform.GetChild(2).transform.localRotation * Vector3.right;
            
            print(Player.transform.GetChild(2).transform.localRotation);
            print(dir2);
            print(Vector3.forward);

            Player.transform.localPosition += dir2 * 0.5f;

            

        
    }
}
