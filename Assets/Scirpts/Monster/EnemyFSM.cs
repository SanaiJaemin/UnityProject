using System.Collections;
using UnityEngine;

public class EnemyFSM : EnemyBase
{
    public enum State
    {
        Idle,
        Move,
        Attack
    };

    public State currentState = State.Idle;

    WaitForSeconds Delay500 = new WaitForSeconds(0.5f);
    WaitForSeconds Delay250 = new WaitForSeconds(0.25f);

    new void Start()
    {
        base.Start();
        parentRoom = transform.parent.transform.parent.gameObject;
       

        StartCoroutine(FSM());
    }
    protected virtual void InitMonster() { }

    protected virtual IEnumerator FSM()
    {
        yield return null;

        while (!parentRoom.GetComponent<Ground>().playerInThisRoom)
        {
            yield return Delay500;
        }

        InitMonster();

        while (true)
        {
            yield return StartCoroutine(currentState.ToString());
        }
    }

    protected virtual IEnumerator Idle()
    {
        yield return null;
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            _animator.SetTrigger("Idle");
        }

        if (CanAtkStateFun())
        {
            if (canAttack)
            {
                currentState = State.Attack;
            }
            else
            {
                currentState = State.Idle;
                transform.LookAt(Player.transform.position);
            }
        }
        else
        {
            currentState = State.Move;
        }
    }

    protected virtual void AtkEffect() { }

    protected virtual IEnumerator Attack()
    {
        yield return null;
        //Atk

        _nvAgent.stoppingDistance = 0f;
        _nvAgent.isStopped = true;
        _nvAgent.SetDestination(Player.transform.position);
        yield return Delay500;

        _nvAgent.isStopped = false;
        _nvAgent.speed = 30f;
        canAttack = false;

        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
        {
            _animator.SetTrigger("Attack");
        }
        AtkEffect();
        yield return Delay500;

        _nvAgent.speed = moveSpeed;
        _nvAgent.stoppingDistance = attackRange;
        currentState = State.Idle;
    }

    protected virtual IEnumerator Move()
    {
        yield return null;
        //Move
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            _animator.SetTrigger("Walk");
        }
        if (CanAtkStateFun() && canAttack)
        {
            currentState = State.Attack;
        }
        else if (distance > playerRealizeRange)
        {
            _nvAgent.SetDestination(transform.parent.position - Vector3.forward * 5f);
        }
        else
        {
            _nvAgent.SetDestination(Player.transform.position);
        }
    }
}
