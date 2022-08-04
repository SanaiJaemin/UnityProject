using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//EnemyDuck이라는 Enemy오브젝트의 클래스 EnemyBase의 값과 EnemyMeleeFSM의 값을 모두 상속받는다
public class EnemyTurtle : EnemyFSM
{
    public GameObject enemyCanvasGo; //체력바
    public GameObject meleeAtkArea; //Sphere Collider를 이용한 공격 사거리 콜라이더
    public Material _material;

    
    


    //플레이어 인식범위와 공격사거리를 OnDrawGizmos 함수를 통해 시각화함
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerRealizeRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    // Start is called before the first frame update
     new void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        _material = GetComponentInChildren<SkinnedMeshRenderer>().material;
        attackCoolTime = 2f; //해당 오브젝트의 공격 쿨타입 초기화
        attackCoolTimeCacl = attackCoolTime; //초기화된 쿨타임으로 현재 쿨타임적용

        attackRange = 3f; //해당 오브젝트의 공격 사거리 초기화
        _nvAgent.stoppingDistance = 3f; //해당 오브젝트의 stoppingDistance 초기화
        
        StartCoroutine(updatePath());
    }

    IEnumerator updatePath()
    {
        while (true)
        {
        _nvAgent.SetDestination(Player.transform.position);
        yield return new WaitForSeconds(0.25f);

        }
    }

    //몬스터의 체력과 공격력을 스테이지 진행 상황에 따라 초기화하는 함수

    void Update()
    {
        
        //Enemy가 죽으면
        if (currentHp <= 0)
        {
            _animator.SetBool("Die",true);
            _rigidbody.isKinematic = true; //충돌판정 삭제
            Debug.Log("죽음");
            _nvAgent.isStopped = true; //네비매쉬 정지
            PlayerTarget.Instance.MonsterList.Remove(transform.parent.gameObject); //플레이어가 인식한 Enemy리스트에서 해당오브젝트 삭제
            PlayerTarget.Instance.TargetIndex = -1; //플레이어의 타겟을 초기화시켜서 다른 타겟을 찾게함          
           
        }
    }
    public void Distroy()
    {
        Destroy(transform.parent.gameObject); //해당 오브젝트 삭제   
    }

    IEnumerator AttackColor()
    {
        _material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _material.color = Color.white;
    }
    //콜리전 처리함수

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("Attak", true);

        }

        if (other.CompareTag("Bullet"))
        {
            StartCoroutine(AttackColor());
            enemyCanvasGo.GetComponent<EnemyHpBar>().currentHp -= 100;
            currentHp = enemyCanvasGo.GetComponent<EnemyHpBar>().currentHp;
            Debug.Log("체력 :" + currentHp);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("Attak", false);

        }
    }



}