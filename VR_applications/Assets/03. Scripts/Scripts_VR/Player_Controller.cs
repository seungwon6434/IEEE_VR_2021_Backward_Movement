using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Player_Controller : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float speed = 1;
    private CharacterController characterController;

    public List<Transform> paths_player = new List<Transform>();

    RaycastHit hit;
    RaycastHit rayHit;
    Ray ray;

    private void Start() 
    {
        Debug.Log("VR 움직임");
        characterController = GetComponent<CharacterController>();

        ray = new Ray();
        ray.origin = this.transform.position;
    }
    // Update is called once per frame
    void Update()
    {

        
        Vector3 direction = Player.instance.hmdTransform. TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));

        //transform.position += speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up);
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);

        this.transform.position += direction;
        //transform.Translate(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);
        // Debug.Log(direction);

        /*
        ray.direction = direction;

        if (Physics.Raycast(transform.position, ray.direction, out rayHit, 1.5f))
        {
            print(rayHit.collider.gameObject.tag);
        }
        */
    }

    void OnTriggerEnter(Collider other)
    {

        
        if (other.CompareTag("Node"))
        {
            paths_player = GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().paths;
            foreach (Transform path in paths_player)
            {
                Renderer rend = path.GetComponent<Renderer>();
                rend.material.color = Color.white;
                // rend.gameObject.tag = "Node";
            }

            //    Debug.Log(other.gameObject);
            Debug.Log("노드 태그");
            GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().setNode(other.gameObject.transform, GameObject.Find("node (end)").transform);
            //Debug.Log(other.gameObject);


        }

        else if (other.CompareTag("end"))
        {
            Debug.Log("앤드 태그");

        }

        else if (other.CompareTag("start"))
        {
            Debug.Log("스타트 태그");

        }
        
       
    }
}
