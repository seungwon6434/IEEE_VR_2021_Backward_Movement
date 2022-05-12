using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Player_controller_Mono : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float speed = 1;
    private CharacterController characterController;

    public List<Transform> paths_player = new List<Transform>();

    RaycastHit hit;
    RaycastHit rayHit;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("VR 움직임");
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = GetComponentInChildren<Camera>().transform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);

    }
}
