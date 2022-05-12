using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


using Debug = UnityEngine.Debug;

public class GenerateGrid : MonoBehaviour
{

    public int row = 2;
    public int column = 2;
    public float padding = 3f;
    public Transform nodePrefab;

    private int mid = 0;
    private int center = 0;
    private int up_left = 0;

    public List<Transform> grid = new List<Transform>();

    public Transform startNode;
    public Transform endNode;

    private bool complete = false; // 사망상태
    private bool available = true;

    RaycastHit rayHit;
    Ray ray;
 
    static int[] seed_1 = new int[] { 10, 15, 20, 21, 86, 95, 88, 100, 200, 541};
    static int[] seed_2 = new int[] { 11, 16, 21, 22, 87, 96, 89, 101, 201, 542 };

    public List<Transform> Normals = new List<Transform>();

    public List<int> five = new List<int>();
    public List<Transform> paths = new List<Transform>();

    public List<int> points = new List<int>();

    private Stopwatch sw_total;
    private Stopwatch sw_temp;

    static int seed = 0;
    static int seed__1 = 0;


    // Use this for initialization
    void Start()
    {

        mid = column / 2;

        up_left = row * (row - 1);
        center = row * mid + mid;

        points.Add(up_left);
        points.Add(center);

        sw_total = new Stopwatch();
        sw_temp = new Stopwatch();

        this.generateGrid();

        this.setNode(GameObject.Find("node (start)").transform, GameObject.Find("node (end)").transform);

        sw_temp.Start();

    }

    void Update()
    {
        //btnFindPath();

        if (sw_temp.ElapsedMilliseconds > 2000) // 2초마다 화재 업데이트
        {
            // Debug.Log(sw_temp.ElapsedMilliseconds);

            foreach (Transform path in paths)
            {
                Renderer rend = path.GetComponent<Renderer>();
                //rend.material.color = Color.white;
                rend.gameObject.tag = "Node";
            }

            // }
            //this.FreeNode();
            //this.UpdateFire();
            this.generateNeighbours();
            //this.generateGrid();

            sw_temp.Reset();
            sw_temp.Start();
           // btnFindPath();

            // Debug.Log(sw_temp.ElapsedMilliseconds);
        }
    }

    void FixedUpdate() 
    {
        
        var follower_total = GameObject.Find("Sphere").GetComponent<Ball_Movement_SP>().sw_follower_total;
        print(follower_total.ElapsedMilliseconds);
        if (follower_total.ElapsedMilliseconds > 100) 
        {
            this.UpdateFire();
            follower_total.Restart();
        }
        
    }

    /// <summary>
    /// Generate the grid with the node.
    /// </summary>
    public void generateGrid()
    {
        //Debug.Log("이거는 실행이 안되나22?");

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                //print(mid);
                int pos = (row) * i + j;

                Transform node = Instantiate(nodePrefab, new Vector3((j * padding) + gameObject.transform.position.x, gameObject.transform.position.y, (i * padding) + gameObject.transform.position.z), Quaternion.identity);
                grid.Add(node);

                if (pos == 0) // 출발
                {
                    //node.gameObject.tag = "begin";
                    node.name = "node (start)";
                    node.GetComponent<MeshRenderer>().material.color = Color.blue;
                }


                else if (pos == row * column - 1) // 종료
                {
                    // node.gameObject.tag = "finish";
                    node.name = "node (end)";
                    node.GetComponent<MeshRenderer>().material.color = Color.yellow;
                }

                //------------------------------------------------------------------------------

                else if (i < mid && j > mid) 
                {
                    node.name = "node (" + pos + ")";
                    node.GetComponent<Node>().setWalkable(false);
                    node.gameObject.tag = "block";
                    node.GetComponent<MeshRenderer>().material.color = Color.black;
                }

                else if (i == 0) // 노말 생성
                {
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }

                else if (j == 0) // 노말 생성
                {
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }

                else if (i == column - 1) // 노말 생성
                {
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }

                else if (j == row - 1) // 노말 생성
                {
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }

                else if (j == mid && i <= mid) // 노말 생성
                {
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }

                else if (i == mid && j >= mid) // 노말 생성
                {
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }

                else // 맵 만들기
                {
                    node.name = "node (" + pos + ")";
                    node.GetComponent<Node>().setWalkable(false);
                    node.gameObject.tag = "block";
                    node.GetComponent<MeshRenderer>().material.color = Color.black;
                }


                /*

                else if (i == 0)
                {
                    // node.gameObject.tag = "finish";
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }

                else if (i == column - 1)
                {
                    // node.gameObject.tag = "finish";
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }

                else if (j == 0)
                {
                    // node.gameObject.tag = "finish";
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }

                else if (j == column - 1)
                {
                    // node.gameObject.tag = "finish";
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                //-----------------------------------------------------------------------------------

                else if ((j == (column - 1) / 2) && (i == (column - 1) / 2))
                {
                    node.name = "node (" + pos + ")";
                    node.GetComponent<Node>().setWalkable(false);
                    node.gameObject.tag = "block";
                    node.GetComponent<MeshRenderer>().material.color = Color.black;
                }

                else if (j == (column - 1) / 2)
                {
                    // node.gameObject.tag = "finish";
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }

                else if (i == (column - 1) / 2)
                {
                    // node.gameObject.tag = "finish";
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                //---------------------------------------------------------------------------------------------------------
                else if ((i == mid - 1) && ((j == mid - 1) || (j == mid + 1)))
                {
                    // node.gameObject.tag = "finish";
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }

                else if ((i == mid + 1) && ((j == mid - 1) || (j == mid + 1)))
                {
                    // node.gameObject.tag = "finish";
                    node.name = "node (" + pos + ")";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                }

                //=---------------------------------------------------------------------------------------------------------
                /*
                else if (five.Contains(pos)) // 불
                {
                    // node.gameObject.tag = "finish";
                    node.name = "node (" + pos + ")";
                    node.GetComponent<Node>().setWalkable(false);
                    node.gameObject.tag = "fire";
                    node.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                */

                //-----------------------------------------------------------------------------------
                /*
                else // 맵 만들기
                {
                    node.name = "node (" + pos + ")";
                    node.GetComponent<Node>().setWalkable(false);
                    node.gameObject.tag = "block";
                    node.GetComponent<MeshRenderer>().material.color = Color.black;
                }
                */

            }
        }
        this.generateNeighbours();
    }


    public void FreeNode()
    {
        var Blocks = GameObject.FindGameObjectsWithTag("Node");
        foreach (var B in Blocks) Destroy(B);
        grid.Clear();
    }

    public void UpdateFire()
    {
        //Debug.Log("이건");

        // List<GameObject> Nodes = new List<GameObject>();
        var Nodes = GameObject.FindGameObjectsWithTag("Node");
        var Blocks = GameObject.FindGameObjectsWithTag("fire");


        foreach (var B in Blocks)
        {
            //Destroy(B);
            if (!(paths.Contains(B.transform)))
            {
                B.GetComponent<Node>().setWalkable(true);
                B.gameObject.tag = "Node";
                B.GetComponent<MeshRenderer>().material.color = Color.white;
            }
            
        }

        ShuffleArray<GameObject>(Nodes);

        points.Reverse();
        var tt = points.GetRange(0, 1);

        for (int i = 0; i < 1; i++)
        {
            GameObject temp = GameObject.Find("node (" + tt[0] + ")");
            temp.GetComponent<Node>().setWalkable(false);
            temp.gameObject.tag = "fire";
            temp.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public void btnFindPath()
    {
        if (startNode != null && endNode != null)
        {        
            foreach (Transform path in paths)
            {
                if (!path.CompareTag("fire"))
                {
                    
                    Renderer rend = path.GetComponent<Renderer>();
                    rend.material.color = Color.white;
                } 
            }

            paths.Clear();

            //startNode = GameObject.Find("node (start)").transform;
            endNode = GameObject.Find("node (end)").transform;

            // Execute Shortest Path.
            ShortestPath finder = gameObject.GetComponent<ShortestPath>();
            paths = finder.findShortestPath(startNode, endNode);

            foreach (Transform path in paths)
            {
               // Debug.Log("그린?");
                //Debug.Log(path.ToString());

                Renderer rend = path.GetComponent<Renderer>();
                rend.material.color = Color.green;
                //this.GetComponent<GenerateGrid>().generateGrid();
                //GameObject.Find("PathMake 1").GetComponent<GenerateGrid>().FreeNode();
                //complete = true;
            }
            // }

            if (paths.Count == 1)
                available = false;

            else
                available = true;

            // available = true;
            // Debug.Log("트루로 바꿈~");
        }




    }


    public void setNode(Transform start, Transform end)
    {
        startNode = start;
        endNode = end;
    }


    /// <summary>
    /// Generate the neighbours for each node.
    /// </summary>
    private void generateNeighbours()
    {
        for (int i = 0; i < grid.Count; i++)
        {
            Node currentNode = grid[i].GetComponent<Node>();
            int index = i + 1;

            // For those on the left, with no left neighbours
            if (index % column == 1)
            {
                // We want the node at the top as long as there is a node.
                if (i + column < column * row)
                {
                    currentNode.addNeighbourNode(grid[i + column]);   // North node
                }

                if (i - column >= 0)
                {
                    currentNode.addNeighbourNode(grid[i - column]);   // South node
                }
                currentNode.addNeighbourNode(grid[i + 1]);     // East node
            }

            // For those on the right, with no right neighbours
            else if (index % column == 0)
            {
                // We want the node at the top as long as there is a node.
                if (i + column < column * row)
                {
                    currentNode.addNeighbourNode(grid[i + column]);   // North node
                }

                if (i - column >= 0)
                {
                    currentNode.addNeighbourNode(grid[i - column]);   // South node
                }
                currentNode.addNeighbourNode(grid[i - 1]);     // West node
            }

            else
            {
                // We want the node at the top as long as there is a node.
                if (i + column < column * row)
                {
                    currentNode.addNeighbourNode(grid[i + column]);   // North node
                }

                if (i - column >= 0)
                {
                    currentNode.addNeighbourNode(grid[i - column]);   // South node
                }
                currentNode.addNeighbourNode(grid[i + 1]);     // East node
                currentNode.addNeighbourNode(grid[i - 1]);     // West node
            }

        }
    }

    public static void ShuffleList<T>(List<T> list)
    {
        int random1;
        int random2;

        T tmp;

        for (int index = 0; index < list.Count; ++index)
        {
            if (seed__1 == 10) seed__1 = 0;

            UnityEngine.Random.seed = seed_1[seed__1];
            random1 = UnityEngine.Random.Range(0, list.Count);

            UnityEngine.Random.seed = seed_2[seed__1];
            random2 = UnityEngine.Random.Range(0, list.Count);

            ++seed__1;

            tmp = list[random1];
            list[random1] = list[random2];
            list[random2] = tmp;
        }

    }

    public static void ShuffleArray<T>(T[] array)
    {
        int random1;
        int random2;

        
        T tmp;

        for (int index = 0; index < array.Length; ++index)
        {
            if (seed == 10) seed = 0;
            
            UnityEngine.Random.seed = seed_1[seed];
            random1 = UnityEngine.Random.Range(0, array.Length);

            UnityEngine.Random.seed = seed_2[seed];
            random2 = UnityEngine.Random.Range(0, array.Length);

            ++seed;

            tmp = array[random1];
            array[random1] = array[random2];
            array[random2] = tmp;


        }
    }




}