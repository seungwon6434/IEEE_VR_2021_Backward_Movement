using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraTransform : MonoBehaviour
{
    [SerializeField]
    private Transform follow = null;

    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;

    private void Awake()
    {
        originalLocalPosition = follow.localPosition;
        originalLocalRotation = follow.localRotation;
    }

    private void Update()
    {

        //transform.rotation = follow.rotation;
        
        
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            //move the parent to child's position
            transform.position = follow.position;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            //HAS TO BE IN THIS ORDER
            //sort of "reverses" the quaternion so that the local rotation is 0 if it is equal to the original local rotation
            follow.RotateAround(follow.position, follow.forward, -originalLocalRotation.eulerAngles.z);
            follow.RotateAround(follow.position, follow.right, -originalLocalRotation.eulerAngles.x);
            follow.RotateAround(follow.position, follow.up, -originalLocalRotation.eulerAngles.y);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            //rotate the parent
            transform.rotation = follow.rotation;
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            //moves the parent by the child's original offset from the parent
            transform.position += -transform.right * originalLocalPosition.x;
            transform.position += -transform.up * originalLocalPosition.y;
            transform.position += -transform.forward * originalLocalPosition.z;
        }

        if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            //resets local rotation, undoing step 2
            follow.localRotation = originalLocalRotation;
        }

        if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            //reset local position
            follow.localPosition = originalLocalPosition;
        }

    }

}
