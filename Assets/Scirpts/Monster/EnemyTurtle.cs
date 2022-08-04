using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//EnemyDuck�̶�� Enemy������Ʈ�� Ŭ���� EnemyBase�� ���� EnemyMeleeFSM�� ���� ��� ��ӹ޴´�
public class EnemyTurtle : EnemyFSM
{
    public GameObject enemyCanvasGo; //ü�¹�
    public GameObject meleeAtkArea; //Sphere Collider�� �̿��� ���� ��Ÿ� �ݶ��̴�
    public Material _material;

    
    


    //�÷��̾� �νĹ����� ���ݻ�Ÿ��� OnDrawGizmos �Լ��� ���� �ð�ȭ��
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
        attackCoolTime = 2f; //�ش� ������Ʈ�� ���� ��Ÿ�� �ʱ�ȭ
        attackCoolTimeCacl = attackCoolTime; //�ʱ�ȭ�� ��Ÿ������ ���� ��Ÿ������

        attackRange = 3f; //�ش� ������Ʈ�� ���� ��Ÿ� �ʱ�ȭ
        _nvAgent.stoppingDistance = 3f; //�ش� ������Ʈ�� stoppingDistance �ʱ�ȭ
        
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

    //������ ü�°� ���ݷ��� �������� ���� ��Ȳ�� ���� �ʱ�ȭ�ϴ� �Լ�

    void Update()
    {
        
        //Enemy�� ������
        if (currentHp <= 0)
        {
            _animator.SetBool("Die",true);
            _rigidbody.isKinematic = true; //�浹���� ����
            Debug.Log("����");
            _nvAgent.isStopped = true; //�׺�Ž� ����
            PlayerTarget.Instance.MonsterList.Remove(transform.parent.gameObject); //�÷��̾ �ν��� Enemy����Ʈ���� �ش������Ʈ ����
            PlayerTarget.Instance.TargetIndex = -1; //�÷��̾��� Ÿ���� �ʱ�ȭ���Ѽ� �ٸ� Ÿ���� ã����          
           
        }
    }
    public void Distroy()
    {
        Destroy(transform.parent.gameObject); //�ش� ������Ʈ ����   
    }

    IEnumerator AttackColor()
    {
        _material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _material.color = Color.white;
    }
    //�ݸ��� ó���Լ�

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
            Debug.Log("ü�� :" + currentHp);
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