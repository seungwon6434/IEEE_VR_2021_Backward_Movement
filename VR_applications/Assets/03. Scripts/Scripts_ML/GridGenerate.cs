using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerate : MonoBehaviour
{
    public int row = 2;
    public int column = 2;
    public float padding = 3f;

    private int mid = 0;
    private int center = 0;
    private int up_left = 0;

    public Transform nodePrefab_block;
    public Transform Node;
    public Transform Cube_end;
    public Transform block;

    public List<Transform> grid = new List<Transform>();
    public List<int> randArray = new List<int>();

    public List<Transform> Normals = new List<Transform>();
    public List<int> five = new List<int>();

    public List<int> points = new List<int>();

    public List<GameObject> green = new List<GameObject>();

    static int seed__1 = 0;

    // Use this for initialization
    void Start()
    {
        // Debug.Log("GG_start");

        mid = column / 2;

        up_left = row * (row - 1);
        center = row* mid +mid;
        
        points.Add(up_left);
        points.Add(center);
        
        this.generateGrid();
        //this.UpdateFire();
        //Debug.Log("여기서 시작인가?");

    }

    /// <summary>
    /// Generate the grid with the node.
    /// </summary>
    public void generateGrid()
    {
        Debug.Log("GG_generateGrid");

        //this.FreeNode();
        //five.Clear();
        
        int counter = 0;

        

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                int pos = (row) * i + j;


                Transform node = Instantiate(Node, new Vector3((j * padding) + gameObject.transform.position.x, gameObject.transform.position.y, (i * padding) + gameObject.transform.position.z), Quaternion.identity);

                if (pos == row * column - 1) // 끝
                {

                    node.name = "node ( end )";
                    node.gameObject.tag = "end";
                    node.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    //node_e.GetComponent<Collider>().isTrigger = true;

                    grid.Add(node);
                    counter++;
                }

                else if (pos == 0) // 출발
                {

                    node.name = "node ( start )";
                    node.gameObject.tag = "start";
                    node.GetComponent<MeshRenderer>().material.color = Color.blue;
                    //node_s.GetComponent<Collider>().isTrigger = true;

                    grid.Add(node);
                    counter++;
                }

                else if (i < mid && j > mid) // 블록 생성
                {

                    node.name = "node (" + pos + ")";
                    node.gameObject.tag = "block";
                    node.GetComponent<MeshRenderer>().material.color = Color.black;
                    //node.GetComponent<Collider>().isTrigger = true;
                    grid.Add(node);

                    counter++;
                }

                else if (i == 0) // 노말 생성
                {
                    // print(pos); 3번 구역

                    node.name = "node (" + pos + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    grid.Add(node);

                    Normals.Add(node);
                    counter++;
                }

                else if (j == 0) // 노말 생성
                {
                    // print(pos); 1번 구역 

                    node.name = "node (" + pos + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    grid.Add(node);

                    Normals.Add(node);
                    counter++;
                }

                else if (i == column - 1) // 노말 생성
                {
                    // print(pos); 2번 구역

                    node.name = "node (" + pos + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    grid.Add(node);

                    Normals.Add(node);
                    counter++;
                }

                else if (j == row - 1) // 노말 생성
                {
                    // print(pos); 6번 구역

                    node.name = "node (" + pos + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    grid.Add(node);

                    Normals.Add(node);
                    counter++;
                }

                else if (j == mid && i<=mid) // 노말 생성
                {
                    // print(pos); 4번 구역

                    node.name = "node (" + pos + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    grid.Add(node);

                    Normals.Add(node);
                    counter++;
                }

                else if (i == mid && j>=mid) // 노말 생성
                {
                    // print(pos); 5번 구역 

                    node.name = "node (" + pos + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    grid.Add(node);

                    Normals.Add(node);
                    counter++;
                }

                

                else {
                    node.name = "node (" + pos + ")";
                    node.gameObject.tag = "block";
                    node.GetComponent<MeshRenderer>().material.color = Color.black;
                }


                /*
                else if (i == column - 1) // 노말 생성
                {

                    node.name = "node (" + counter + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    numArray.Add(pos);
                    grid.Add(node);
                    counter++;
                }

                else if (j == 0) // 노말 생성
                {

                    node.name = "node (" + counter + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    numArray.Add(pos);
                    grid.Add(node);
                    counter++;
                }

                else if (j == column - 1) // 노말 생성
                {

                    node.name = "node (" + counter + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    numArray.Add(pos);
                    grid.Add(node);
                    counter++;
                }

                else if ((j == (column - 1) / 2) && (i == (column - 1) / 2)) // 블럭 생성
                {
                    //  Debug.Log("여기");

                    node.name = "node (" + counter + ")";
                    node.gameObject.tag = "block";
                    node.GetComponent<MeshRenderer>().material.color = Color.black;
                    //node_b.GetComponent<Collider>().isTrigger = false;

                    grid.Add(node);
                    counter++;
                    array_count++;

                }

                else if (j == (column - 1) / 2) // 노말 생성
                {

                    node.name = "node (" + counter + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    numArray.Add(pos);
                    grid.Add(node);
                    counter++;
                }

                else if (i == (column - 1) / 2) // 노말 생성
                {

                    node.name = "node (" + counter + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    numArray.Add(pos);
                    grid.Add(node);
                    counter++;
                }

                else if ((i == mid - 1) && ((j == mid - 1) || (j == mid + 1))) // 노말 생성
                {

                    node.name = "node (" + counter + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    numArray.Add(pos);
                    grid.Add(node);
                    counter++;
                }

                else if ((i == mid + 1) && ((j == mid - 1) || (j == mid + 1))) // 노말 생성
                {

                    node.name = "node (" + counter + ")";
                    node.gameObject.tag = "normal";
                    node.GetComponent<MeshRenderer>().material.color = Color.white;
                    //node.GetComponent<Collider>().isTrigger = true;

                    numArray.Add(pos);
                    grid.Add(node);
                    counter++;
                }

                else // 맵 만들기
                {

                    node.name = "node (" + counter + ")";
                    node.gameObject.tag = "block";
                    node.GetComponent<MeshRenderer>().material.color = Color.black;
                    //node_b.GetComponent<Collider>().isTrigger = false;

                    grid.Add(node);
                    counter++;
                    array_count++;
                }
                */

                /*
                else if (five.Contains(pos)) // fire 생성
                {
                    Transform node = Instantiate(Node, new Vector3((j * padding) + gameObject.transform.position.x, gameObject.transform.position.y, (i * padding) + gameObject.transform.position.z), Quaternion.identity);
                    node.name = "node (" + counter + ")";
                    node.gameObject.tag = "fire";
                    node.GetComponent<MeshRenderer>().material.color = Color.red;
                    //node.GetComponent<Collider>().isTrigger = true;

                    grid.Add(node);
                    counter++;
                }
                */

            }


        }
    }

    public void FreeNode()
    {
        // Debug.Log("GG_FreeNode");

        var Blocks = GameObject.FindGameObjectsWithTag("block");
        var Starts = GameObject.FindGameObjectsWithTag("start");
        var Ends = GameObject.FindGameObjectsWithTag("end");
        var Normals = GameObject.FindGameObjectsWithTag("normal");
        var Fires = GameObject.FindGameObjectsWithTag("fire");


        //foreach (var B in Blocks) Destroy(B);
        //foreach (var S in Starts) Destroy(S);
        //foreach (var E in Ends) Destroy(E);
        //foreach (var N in Normals) Destroy(N);
        //foreach (var F in Fires) Destroy(F);

        foreach (var F in Fires)
        {
            F.gameObject.tag = "normal";

            F.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        //ShuffleList<int>(numArray);
        //five = numArray.GetRange(0, 2);
    

        foreach (var f in five)
        {
            GameObject temp = GameObject.Find("node (" + f + ")");
            temp.gameObject.tag = "fire";
            temp.GetComponent<MeshRenderer>().material.color = Color.red;
        }


    }

    public void UpdateFire()
    {
//        print("업데이트 퐈이어");

        var Fires = GameObject.FindGameObjectsWithTag("fire");

        green = GameObject.Find("Sphere").GetComponent<PathAgent>().getGreen();
        
        foreach (var F in Fires) // 기존의 fire를 fire가 아니도록 해제 해주는 과정 (빨간색 -> 흰색)
        {
            F.gameObject.tag = "normal";
            F.gameObject.layer = LayerMask.NameToLayer("Default");

            var color = F.GetComponent<MeshRenderer>().material.color;

            if (green.Contains(F))
                F.GetComponent<MeshRenderer>().material.color = Color.green;

            else
                F.GetComponent<MeshRenderer>().material.color = Color.white;

        }
        
        ShuffleList<Transform>(Normals);

        var nom = Normals.GetRange(0, 1);

        points.Reverse();
        var tt = points.GetRange(0, 1);

        foreach (var f in tt) // 새로운 노드들을 골라서 fire로 만들어주는 과정 (흰색 or 초록색 -> 빨간색)
        {
            //print(f);
            //node.GetComponent<MeshRenderer>().material.color = Color.white;

            GameObject temp = GameObject.Find("node (" + f + ")");

            //int tt = row * mid + mid;
            //GameObject temp = GameObject.Find("node (" + tt + ")");

            if (temp)
            {
                temp.gameObject.tag = "fire";
                temp.gameObject.layer = LayerMask.NameToLayer("ffire");
                temp.GetComponent<MeshRenderer>().material.color = Color.red;
            }


        }

    }

    public static void ShuffleList<T>(List<T> list)
    {
        // Debug.Log("GG_shufflelist");

        int random1;
        int random2;

        T tmp;

        for (int index = 0; index < list.Count; ++index)
        {
            //UnityEngine.Random.seed = 12345;
            if (seed__1 == 10) seed__1 = 0;

            // UnityEngine.Random.seed = seed_1[seed__1];
            random1 = UnityEngine.Random.Range(0, list.Count);

            //UnityEngine.Random.seed = seed_2[seed__1];
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
            random1 = UnityEngine.Random.Range(0, array.Length);
            random2 = UnityEngine.Random.Range(0, array.Length);

            tmp = array[random1];
            array[random1] = array[random2];
            array[random2] = tmp;
        }
    }



}
