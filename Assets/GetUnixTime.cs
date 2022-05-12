using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetUnixTime : MonoBehaviour
{


    public long unixTime;

    // Update is called once per frame
    void Update()
    {
        unixTime = UnixTimeNow();
        //print(unix);
    }

    public long UnixTimeNow()

    {

        var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));

        return (long)timeSpan.TotalSeconds;

    }

}
