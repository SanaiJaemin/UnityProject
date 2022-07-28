using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tuttle : LivingEntity
{
    public LayerMask whatIsTarget;

    private LivingEntity targetEntity;
    private NavMeshAgent _navMeshAgent;

    public ParticleSystem hitEffect;
    public AudioClip DeathClip;
    public AudioClip hitSound;

    private Animator TuttleAnimator;
    private AudioSource _audioSouce;
    private Renderer tuttleRenderer;

    public float damage = 10f;
    public float timeBetAttack = 0.5f;
    private float lastAttackTime;

    private bool hastarget
    {
        get
        {
            if (targetEntity != null && !targetEntity.IsDead)
            {
                return true;
            }
            return false;
        }

    }
    public void Setup(TuttleData tuttleData)
    {
        startingHealth = tuttleData.health;
        CurrentHealth = tuttleData.damage;
        damage = tuttleData.damage;
        _navMeshAgent.speed = tuttleData.speed;



    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitnomal)
    {
        if (!IsDead)
        {
            hitEffect.transform.position = hitPoint;
            hitEffect.transform.rotation = Quaternion.LookRotation(hitnomal);
            hitEffect.Play();

            _audioSouce.PlayOneShot(hitSound);
        }

        base.OnDamage(damage, hitPoint, hitnomal);
    }
    public override void Die()
    {
        base.Die();
        Collider[] colliders = GetComponents<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }
        _navMeshAgent.isStopped = true;
        _navMeshAgent.enabled = false;

        TuttleAnimator.SetTrigger("Die");
        _audioSouce.PlayOneShot(DeathClip);

    }
    // Start is called before the first frame update
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        TuttleAnimator = GetComponent<Animator>();
        _audioSouce = GetComponent<AudioSource>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePath();
    }

    private IEnumerable UpdatePath()
    {
        while (!IsDead)
        {
            if (hastarget)
            {
                _navMeshAgent.isStopped = false;
                _navMeshAgent.SetDestination(targetEntity.transform.position);

            }
            else
            {
                _navMeshAgent.isStopped = true;

                Collider[] _colliders = Physics.OverlapSphere(transform.position, 20f, whatIsTarget);

                for (int i = 0; i < _colliders.Length; i++)
                {
                    LivingEntity _livingEntity = _colliders[i].GetComponent<LivingEntity>();

                    if (_livingEntity != null && !_livingEntity)
                    {
                        targetEntity = _livingEntity;
                        break;
                    }

                }
            }

            yield return new WaitForSeconds(0.25f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!IsDead && Time.time >= lastAttackTime + timeBetAttack)
        {
            LivingEntity attackTarget = other.GetComponent<LivingEntity>();

            if(attackTarget != null && attackTarget == targetEntity)
            {
                lastAttackTime = Time.time;

                Vector3 hitPoint = other.ClosestPoint(transform.position);
                Vector3 hitnomal = transform.position - other.transform.position;

                attackTarget.OnDamage(damage, hitPoint, hitnomal);

            }
        }
    }
}

