using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float MoveSpeed = 5f; // �յ� �������� �ӵ�
    public float RotateSpeed = 180f; // �¿� ȸ�� �ӵ�

    private PlayerInput _input;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private static class AnimID
    {
        public static readonly int MOVE = Animator.StringToHash("Momve");
    }
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
        rotate();
        // ���� ���� �ֱ⸶�� ������, ȸ��, �ִϸ��̼� ó�� ����
        _animator.SetFloat(AnimID.MOVE, _input.MoveDirection);
    }

    // �Է°��� ���� ĳ���͸� �յڷ� ������
    private void move()
    {
        float movementAmount = MoveSpeed * Time.fixedDeltaTime; // �Ÿ���

        Vector3 direction = _input.MoveDirection * transform.forward; // ������ ĳ���� �����̴�.
        Vector3 offset = movementAmount * direction; // �����ΰ� ��ģ��

        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    // �Է°��� ���� ĳ���͸� �¿�� ȸ��
    private void rotate()
    {
        float rotationAmount = _input.Rotate * RotateSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);

    }
}

