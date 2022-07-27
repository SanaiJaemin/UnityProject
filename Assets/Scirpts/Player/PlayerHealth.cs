using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//public class PlayerHealth : LivingEntity
//{
//    {
//    public Slider HealthSlider; // ü���� ǥ���� UI �����̴�

//    public AudioClip DeathClip; // ��� �Ҹ�
//    public AudioClip HitClip; // �ǰ� �Ҹ�
//    public AudioClip ItemPickupClip; // ������ ���� �Ҹ�

//    private AudioSource _audioPlayer; // �÷��̾� �Ҹ� �����
//    private Animator _animator; // �÷��̾��� �ִϸ�����

//    private PlayerMove _movement; // �÷��̾� ������ ������Ʈ
//    private PlayerTarget _shooter; // �÷��̾� ���� ������Ʈ

//    private void Awake()
//    {
//        // ����� ������Ʈ�� ��������
//        _audioPlayer = GetComponent<AudioSource>();
//        _animator = GetComponent<Animator>();

//        _movement = GetComponent<PlayerMove>();
//        _shooter = GetComponent<PlayerTarget>();
//    }

//    protected override void OnEnable()
//    {
//        // LivingEntity�� OnEnable() ���� (���� �ʱ�ȭ)
//        base.OnEnable();

//        // ü�� �����̵带 �ٽ� ����
//        HealthSlider.gameObject.SetActive(true);
//        HealthSlider.maxValue = InitialHealth;
//        HealthSlider.value = CurrentHealth;

//        // ������Ʈ�� �ٽ� Ȱ��ȭ
//        _movement.enabled = true;
//        _shooter.enabled = true;
//    }

//    // ü�� ȸ��
//    public override void RestoreHealth(float newHealth)
//    {
//        // LivingEntity�� RestoreHealth() ���� (ü�� ����)
//        base.RestoreHealth(newHealth);
//        HealthSlider.value = CurrentHealth;
//    }

//    // ������ ó��
//    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitDirection)
//    {
//        // LivingEntity�� OnDamage() ����(������ ����)
//        base.OnDamage(damage, hitPoint, hitDirection);
//        if (IsDead == false)
//        {
//            _audioPlayer.PlayOneShot(HitClip);
//        }
//        HealthSlider.value = CurrentHealth;
//    }

//    // ��� ó��
//    public override void Die()
//    {
//        // LivingEntity�� Die() ����(��� ����)
//        base.Die();

//        HealthSlider.gameObject.SetActive(false);

//        // ������Ʈ�� �ٽ� Ȱ��ȭ
//        _movement.enabled = false;
//        _shooter.enabled = false;

//        _audioPlayer.PlayOneShot(DeathClip);

//        _animator.SetTrigger(PlayerAnimID.Die);
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        // �����۰� �浹�� ��� �ش� �������� ����ϴ� ó��
//        if (IsDead)
//        {
//            return;
//        }

//        IItem item = other.GetComponent<IItem>();
//        if (item != null)
//        {
//            item.Use(gameObject);
//            _audioPlayer.PlayOneShot(ItemPickupClip);
//        }
//    }
//}
