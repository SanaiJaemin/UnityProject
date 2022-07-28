using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float X { get; private set; }
    public float Z { get; private set; }
 
   
    private Animator _animator;
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


        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");




    }








}
