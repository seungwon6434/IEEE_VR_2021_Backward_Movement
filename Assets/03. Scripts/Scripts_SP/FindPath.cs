using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPath : MonoBehaviour
{
    private Transform startNode;
    private Transform endNode;

    private bool path = true; // 사망상태
    private bool block = false;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        btnFindPath();
    }

    public void btnFindPath()
    {
        startNode = GameObject.Find("node (start)").transform;
        endNode = GameObject.Find("node (end)").transform;

        // Only find if there are start and end node.
        if (startNode != null && endNode != null)
        {

            // Execute Shortest Path.
            ShortestPath finder = gameObject.GetComponent<ShortestPath>();
            List<Transform> paths = finder.findShortestPath(startNode, endNode);

            //Debug.Log(startNode);
            //Debug.Log(endNode);
            Debug.Log("길 없으면?");
            Debug.Log(paths.Count.ToString());

            if (paths.Count == 1)
            {
                //GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().FreeNode();
                //GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().generateGrid();
            }



            // Colour the node red.
            foreach (Transform path in paths)
            {
                // Debug.Log("길찾기?");
                //  Debug.Log(path.ToString());

                Renderer rend = path.GetComponent<Renderer>();
                rend.material.color = Color.red;
                //this.GetComponent<GenerateGrid>().generateGrid();
                //GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().FreeNode();
            }
        }
    }
}
