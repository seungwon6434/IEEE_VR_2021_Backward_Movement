using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System.IO;

public class Find_Tracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        uint index = 0;
        var error = ETrackedPropertyError.TrackedProp_Success;

        for (uint i = 0; i < 16; i++)
        {            
            var result = new System.Text.StringBuilder((int)64);
            OpenVR.System.GetStringTrackedDeviceProperty(i, ETrackedDeviceProperty.Prop_RenderModelName_String, result, 64, ref error);

            if (result.ToString().Contains("tracker"))
            {
                print(result.ToString());
                index = i;
                print(i);
                print(result.ToString());
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
