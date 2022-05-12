using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObj : MonoBehaviour
{
    List<Transform> spawnPos = new List<Transform>();
    GameObject[] monsters;

    public GameObject monPrefab;
    public int spawnNumber = 1;
    public float respawnDelay = 3f;

    int deadMonsters = 0;
    void Start()
    {
        MakeSpawnPos();
    }
    void MakeSpawnPos()
    {
        print("MakeSpawnPos");
        foreach (Transform pos in transform)
        {
            print(pos);
            print(pos.tag);


            if (pos.tag == "respawn")
            {
                spawnPos.Add(pos);
            }
        }

        if (spawnNumber > spawnPos.Count)
        {
            spawnNumber = spawnPos.Count;
        }

        print(spawnNumber);
        print(spawnPos.Count);

        monsters = new GameObject[spawnNumber];

        MakeMonsters();
    }

    //프리팹으로 부터 몬스터를 만들어 관리하는 함수
    void MakeMonsters()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            GameObject mon = Instantiate(monPrefab, spawnPos[i].position, Quaternion.identity) as GameObject;
            mon.SetActive(false);


            monsters[i] = mon;
        }
    }

    void SpawnMonster()
    {
        for (int i = 0; i < monsters.Length; i++)
        {
            monsters[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        print(col.gameObject.tag);
        
        if (col.gameObject.tag == "player")
        {
            print("몬스터");
            SpawnMonster();

            //GetComponent() < SphereCollider >.enabled = false;
            //GetComponent<SphereCollider>.
        }

        else if (col.gameObject.tag == "agent")
        {
            print("불");
            Destroy(col.gameObject);


            //GetComponent() < SphereCollider >.enabled = false;
            //GetComponent<SphereCollider>.
        }
    }
    void Update()
    {

    }
}