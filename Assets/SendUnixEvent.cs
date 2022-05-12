using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendUnixEvent : MonoBehaviour
{
    public GameObject Client;
    
    // Start is called before the first frame update
    void Start()
    {
        Client.GetComponent<TCPUnixClient>().SendUnixtime();
    }

}
