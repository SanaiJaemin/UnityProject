using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float maxHP = 100f; // ü��
    public float currentHp = 100f; //���� ü��

    public float damage = 10f; //������

    public float playerRealizeRange = 10f; //�÷��̾� ���� ����
    public float attackRange = 5f; // ���ݹ���
    public float attackCoolTime = 5f; // ���ݼӵ�
    public GameObject Target;
    
    

    private bool dead = false; // �������ΰ�?
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
