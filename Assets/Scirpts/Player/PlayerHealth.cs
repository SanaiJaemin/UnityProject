using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerHealth : LivingEntity
{
    
    //public Slider HealthSlider; // 체력을 표시할 UI 슬라이더

    //public AudioClip DeathClip; // 사망 소리
    //public AudioClip HitClip; // 피격 소리
    //public AudioClip ItemPickupClip; // 아이템 습득 소리

    //private AudioSource _audioPlayer; // 플레이어 소리 재생기
    //private Animator _animator; // 플레이어의 애니메이터

    //private PlayerMove _movement; // 플레이어 움직임 컴포넌트
    //private PlayerTarget _shooter; // 플레이어 슈터 컴포넌트

    //private void Awake()
    //{
    //    // 사용할 컴포넌트를 가져오기
    //    _audioPlayer = GetComponent<AudioSource>();
    //    _animator = GetComponent<Animator>();

    //    _movement = GetComponent<PlayerMove>();
    //    _shooter = GetComponent<PlayerTarget>();
    //}

    //protected override void OnEnable()
    //{
    //    // LivingEntity의 OnEnable() 실행 (상태 초기화)
    //    base.OnEnable();

    //    // 체력 슬라이드를 다시 리셋
    //    HealthSlider.gameObject.SetActive(true);
    //    HealthSlider.maxValue = startingHealth;
    //    HealthSlider.value = CurrentHealth;

    //    // 컴포넌트도 다시 활성화
    //    _movement.enabled = true;
    //    _shooter.enabled = true;
    //}

    //// 체력 회복
    

    //// 데미지 처리
    //public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitDirection)
    //{
    //    // LivingEntity의 OnDamage() 실행(데미지 적용)
    //    base.OnDamage(damage, hitPoint, hitDirection);
    //    if (IsDead == false)
    //    {
    //        _audioPlayer.PlayOneShot(HitClip);
    //    }
    //    HealthSlider.value = CurrentHealth;
    //}

    //// 사망 처리
    //public override void Die()
    //{
    //    // LivingEntity의 Die() 실행(사망 적용)
    //    base.Die();

    //    HealthSlider.gameObject.SetActive(false);

    //    // 컴포넌트도 다시 활성화
    //    _movement.enabled = false;
    //    _shooter.enabled = false;

    //    _audioPlayer.PlayOneShot(DeathClip);

        
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    // 아이템과 충돌한 경우 해당 아이템을 사용하는 처리
    //    if (IsDead)
    //    {
    //        return;
    //    }

        
    //}
}
