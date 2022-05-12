using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    [SerializeField]
    private Transform follow = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetPosition(follow.transform, transform.position);
    }

    public void SetPosition(Transform obj, Vector3 relativePosition)
    {
        // sets the obj to relativePosition in the 
        // local coordinate system of this rotated and translated manager
        obj.position = transform.TransformPoint(relativePosition);

        // adjust the rotation
        // Quaternions are added by multiplying them
        // so first we want the changed coordinate system's rotation
        // then add the rotation it had before
        obj.rotation = transform.rotation * obj.rotation;
    }
}
