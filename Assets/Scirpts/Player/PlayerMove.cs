using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    PlayerInput _input;

    public float moveSpeed = 1f;
    public float rotateSpeed = 1f;

    private Vector3 Movevec;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        
        move();
    
    }

    private void move()
    {
        

        Movevec = new Vector3(_input.X, 0f,_input.Z).normalized;

        transform.position += Movevec * moveSpeed * Time.deltaTime;

        _animator.SetBool("IsRun", Movevec != Vector3.zero);

        transform.LookAt(transform.position + Movevec);
    }
}

