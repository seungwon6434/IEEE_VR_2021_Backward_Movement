using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bus_door_close : MonoBehaviour
{
    public GameObject Bus;
    public GameObject passenger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
            passenger.transform.SetParent(Bus.transform);
            Bus.GetComponent<Animator>().SetTrigger("BusForward");
        }
    }
}