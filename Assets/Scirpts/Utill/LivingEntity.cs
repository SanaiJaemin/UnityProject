using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LivingEntity: MonoBehaviour , IDamageable
{
    public float InitialHealth = 100f; // ���� ü��
    public float CurrentHealth { get; protected set; } // ���� ü��
    public bool IsDead { get; protected set; } // ��� ����
    public event Action onDeath; // ����� �ߵ��� �̺�Ʈ

    // ����ü�� Ȱ��ȭ�ɶ� ���¸� ����
    protected virtual void OnEnable()
    {
        // ������� ���� ���·� ����
        IsDead = false;
        // ü���� ���� ü������ �ʱ�ȭ
        CurrentHealth = InitialHealth;
    }

    // �������� �Դ� ���
    public virtual void OnDamage(float damage, Vector3 hitPoint)
    {
        // ��������ŭ ü�� ����
        CurrentHealth -= damage;

        // ü���� 0 ���� && ���� ���� �ʾҴٸ� ��� ó�� ����
        if (CurrentHealth <= 0 && !IsDead)
        {
            Die();
        }
    }

    // ü���� ȸ���ϴ� ���
    public virtual void RestoreHealth(float newHealth)
    {
        if (IsDead)
        {
            // �̹� ����� ��� ü���� ȸ���� �� ����
            return;
        }

        // ü�� �߰�
        CurrentHealth += newHealth;
    }

    // ��� ó��
    public virtual void Die()
    {
        // onDeath �̺�Ʈ�� ��ϵ� �޼��尡 �ִٸ� ����
        if (onDeath != null)
        {
            onDeath();
        }

        // ��� ���¸� ������ ����
        IsDead = true;
    }
}
