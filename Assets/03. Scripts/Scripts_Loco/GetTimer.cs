using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

using System;
using UnityEngine.UI;

public class GetTimer : MonoBehaviour
{
    private Text direction;
    public Stopwatch Timer;
    public double total_timer;

    // Start is called before the first frame update
    void Awake()
    {
        Timer = new Stopwatch();
    }

    void Start()
    {
        direction = GetComponentInChildren<Text>();
        Timer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        var str = Timer.Elapsed.Seconds.ToString();
        var temp = Timer.Elapsed.TotalSeconds;
        total_timer = Math.Truncate(temp * 100) / 100;

        direction.text = str;
        
    }
}
