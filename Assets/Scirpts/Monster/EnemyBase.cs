using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    public float maxHp = 1000f;
    public float currentHp = 1000f;

    public float damage = 100f;

    protected float playerRealizeRange = 10f;
    protected float attackRange = 5f;
    protected float attackCoolTime = 5f;
    protected float attackCoolTimeCacl = 5f;
    protected bool isPlayer = true;
    protected bool canAttack = true;


    protected float moveSpeed = 2f;

    protected GameObject Player;
    protected NavMeshAgent _nvAgent;
    protected float distance;
    PlayerTarget _playerTarget;

    protected GameObject parentRoom;
    protected Animator _animator;
    protected Rigidbody rb;
    EnemyHpBar _enemyHpBar;

    public LayerMask layerMask;

    // Use this for initialization
    protected void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        _nvAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();



       
    }


 
  
    protected bool CanAtkStateFun()
    {
        RaycastHit hit;
        Vector3 targetDir = new Vector3(Player.transform.position.x - transform.position.x, 0f, Player.transform.position.z - transform.position.z); //방향

        Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z), targetDir, out  hit, 30f);
        distance = Vector3.Distance(Player.transform.position, transform.position); //거리
        Debug.DrawRay(new Vector3(transform.position.x, 0.5f, transform.position.z), targetDir * 30f, Color.green);

        if (hit.transform == null)
        {
            Debug.Log(" hit.transform == null");
            return false;
        }

        if (hit.transform.CompareTag("Player") && distance <= attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual IEnumerator CalcCoolTime()
    {
        while (true)
        {
            yield return null;
            //공격이 시작됬다면 쿨타임 계산 시작
            if (!canAttack)
            {
                //Time.deltaTime만큼 attackCoolTimeCacl계산
                attackCoolTimeCacl -= Time.deltaTime;
                //attackCoolTimeCacl이 0에 근접하면 attackCoolTime값으로 초기화
                if (attackCoolTimeCacl <= 0)
                {
                    attackCoolTimeCacl = attackCoolTime;
                    canAttack = true; //공격이 다시 가능함
                }
            }
        }
    }
}
