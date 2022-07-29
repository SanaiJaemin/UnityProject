using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{


    public bool getATarget = false;
    float currentDist = 0;      //현재 거리
    float closetDist = 100f;    //가까운 거리
    float TargetDist = 100f;   //타겟 거리
    int closeDistIndex = 0;    //가장 가까운 인덱스
    public int TargetIndex = -1;      //타겟팅 할 인덱스
    int prevTargetIndex = 0;
    public LayerMask layerMask;
    public float totalTime = 0f;
    public int monsterCount;

    public float atkSpd = 1f;

    public List<GameObject> MonsterList = new List<GameObject>();
    //Monster를 담는 List 

    public GameObject PlayerBolt;  //발사체
    public Transform AttackPoint;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
    }

    private void Start()
    {
        _animator.CrossFade("Attack", atkSpd);

    }
    // Update is called once per frame
    void Update()
    {

        Attack();
    }

    void Attack()
    {
        if (!_animator.GetBool("IsRun"))
        {
            if (getATarget)
            {
                attackSpeed();
                transform.LookAt(AttackPoint.position);
            }
            else
            {
                attackSpeed();
            }

        }

    }
    void attackSpeed()
    {
        totalTime += Time.deltaTime;

        if (totalTime > atkSpd)
        {
            totalTime = 0f;
            Instantiate(PlayerBolt, AttackPoint.position, transform.rotation);
        }

    }
    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Monster"))
        {
            MonsterList.Add(other.gameObject); // 변경
            Debug.Log("몹 카운터 : " + monsterCount);
            getATarget = true;
            
        }
    }



    private void OnTriggerExit(Collider other)
    {

        getATarget = false;

    }





}
