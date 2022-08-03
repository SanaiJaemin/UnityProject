using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//EnemyDuck�̶�� Enemy������Ʈ�� Ŭ���� EnemyBase�� ���� EnemyMeleeFSM�� ���� ��� ��ӹ޴´�
public class EnemyTurtle : EnemyFSM
{
    public GameObject enemyCanvasGo; //ü�¹�
    public GameObject meleeAtkArea; //Sphere Collider�� �̿��� ���� ��Ÿ� �ݶ��̴�
    

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

        attackCoolTime = 2f; //�ش� ������Ʈ�� ���� ��Ÿ�� �ʱ�ȭ
        attackCoolTimeCacl = attackCoolTime; //�ʱ�ȭ�� ��Ÿ������ ���� ��Ÿ������

        attackRange = 3f; //�ش� ������Ʈ�� ���� ��Ÿ� �ʱ�ȭ
        _nvAgent.stoppingDistance = 3f; //�ش� ������Ʈ�� stoppingDistance �ʱ�ȭ

        Pathup();
    }

    IEnumerator Pathup()
    {
        _nvAgent.SetDestination(Player.transform.position);
        yield return new WaitForSeconds(0.25f);
    }

    //������ ü�°� ���ݷ��� �������� ���� ��Ȳ�� ���� �ʱ�ȭ�ϴ� �Լ�




    // Update is called once per frame
    void Update()
    {
        //Enemy�� ������
        if (currentHp <= 0)
        {
            _nvAgent.isStopped = true; //�׺�Ž� ����

            rb.gameObject.SetActive(false); //�浹���� ����
            PlayerTarget.Instance.MonsterList.Remove(transform.parent.gameObject); //�÷��̾ �ν��� Enemy����Ʈ���� �ش������Ʈ ����
            PlayerTarget.Instance.TargetIndex = -1; //�÷��̾��� Ÿ���� �ʱ�ȭ���Ѽ� �ٸ� Ÿ���� ã����
            Destroy(transform.parent.gameObject); //�ش� ������Ʈ ����
            return;
        }
    }

    //�ݸ��� ó���Լ�
    private void OnCollisionEnter(Collision collision)
    {
        //Enemy�� Potato�� ������
        if (collision.transform.CompareTag("Bullet"))
        {
            currentHp -= 250f; //ü�°���
            
        }
    }

}