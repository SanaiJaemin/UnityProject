using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float maxHP = 100f; // 체력
    public float currentHp = 100f; //현재 체력

    public float damage = 10f; //데미지

    public float playerRealizeRange = 10f; //플레이어 감지 범위
    public float attackRange = 5f; // 공격범위
    public float attackCoolTime = 5f; // 공격속도
    public GameObject Target;
    
    

    private bool dead = false; // 공격중인가?
    private NavMeshAgent _navMeshAgents;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        
        _navMeshAgents = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(UpdatePath());
    }
    private IEnumerator UpdatePath()
    {
        while (true)
        {
            _navMeshAgents.SetDestination(Target.transform.position);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        { 
            Destroy(gameObject);
            

        }
    }
    
    

    





}
