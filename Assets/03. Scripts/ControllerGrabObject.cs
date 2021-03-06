using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    private GameObject collidingObject;
    private GameObject objectInHand;
    public GameObject Warning;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print(grabAction.GetLastStateDown(handType));
        //print(grabAction.GetStateDown(handType));
        //print(grabAction.GetStateUp(handType));

        if (grabAction.GetLastStateDown(handType))
        {
            //print("잡기");
            if (collidingObject)
            {
                //  print("잡기2");
                GrabObject();


            }
        }

        if (grabAction.GetLastStateUp(handType))
        {
            //print("놓기");
            if (collidingObject)
            {
                //  print("놓기2");
                ReleaseObject();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
            return;

        collidingObject = null;
    }





    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = col.gameObject;
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity =
                controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity =
                controllerPose.GetAngularVelocity();
        }

        objectInHand = null;
    }
}
