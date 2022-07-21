using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float MoveSpeed = 5f; // 앞뒤 움직임의 속도
    public float RotateSpeed = 180f; // 좌우 회전 속도

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
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
        _animator.SetFloat(AnimID.MOVE, _input.MoveDirection);
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void move()
    {
        float movementAmount = MoveSpeed * Time.fixedDeltaTime; // 거리량

        Vector3 direction = _input.MoveDirection * transform.forward; // 방향은 캐릭터 기준이다.
        Vector3 offset = movementAmount * direction; // 위에두개 합친거

        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void rotate()
    {
        float rotationAmount = _input.Rotate * RotateSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);

    }
}

