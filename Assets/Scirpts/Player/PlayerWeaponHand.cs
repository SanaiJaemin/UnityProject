using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHand : MonoBehaviour
{
    public Transform WeaponPitvot;
    public Transform RightHandMount;

    private PlayerInput _input;
    private Animator _animator;

   

    // Start is called before the first frame update
    void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnAnimatorIK(int layerIndex)
    {

        _animator.SetIKPositionAndWeight(AvatarIKGoal.RightHand, RightHandMount);
    }
}
