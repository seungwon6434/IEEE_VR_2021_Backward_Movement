using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // AI 사용 (네비게이션)
public class Enemy_Movement : MonoBehaviour
{
    private Transform player; // 플레이어 Transform
    public Animator animator; // 몬스터의 애니메이터
    public NavMeshAgent navMeshAgent; // 길찾기 에이전트
    //public EnemyHealth health; // 몬스터 체력
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        // Player란 이름의 게임오브젝트를 찾아 그 게임오브젝트의 transform을 참조함
        player = GameObject.Find("Keyboard_player").transform;
        anim = GetComponent<Animation>();

        
    }

    // Update is called once per frame
    void Update()
    {
        // if (health.currentHealth > 0)
        //  {
        
        // 플레이어를 추적해라
        navMeshAgent.destination = player.transform.position;
        


        // }
        // else
        // {
        // 이동을 중지함
        // navMeshAgent.isStopped = true;
        //navMeshAgent.enabled = false;
        //}

    }
}




