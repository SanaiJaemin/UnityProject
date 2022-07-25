using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float X { get; private set; }
    public float Z { get; private set; }
    public float speed;


    private Animator _animator;
    private Vector3 Movevec;
    private Rigidbody _rigidbody;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        Move();



    }

    void Move()
    {
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        Movevec = new Vector3(X, 0f, Z).normalized;

        transform.position += Movevec * speed * Time.deltaTime;
        _animator.SetBool("IsRun", Movevec != Vector3.zero);

        transform.LookAt(transform.position + Movevec);
    }

}