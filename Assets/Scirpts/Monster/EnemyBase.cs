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

    protected float moveSpeed = 2f;

    protected GameObject Player;
    protected NavMeshAgent nvAgent;
    protected float distance;
    PlayerTarget _playerTarget;

    protected GameObject parentRoom;

    protected Animator Anim;
    protected Rigidbody rb;

    public LayerMask layerMask;

    // Use this for initialization
    protected void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        nvAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();



        StartCoroutine(updatePath());
    }

    
    private IEnumerator updatePath()
    {
        while (true)
        {
            nvAgent.SetDestination(Player.transform.position);

            yield return new WaitForSeconds(0.25f);

        }

    }
    protected bool CanAtkStateFun()
    {
        Vector3 targetDir = new Vector3(Player.transform.position.x - transform.position.x, 0f, Player.transform.position.z - transform.position.z);

        Physics.Raycast(new Vector3(transform.position.x, 0.5f, transform.position.z), targetDir, out RaycastHit hit, 30f, layerMask);
        distance = Vector3.Distance(Player.transform.position, transform.position);

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

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            
            
        }
    }
}
