using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{


    public bool getATarget = false;
    float currentDist = 0;      //���� �Ÿ�
    float closetDist = 100f;    //����� �Ÿ�
    float TargetDist = 100f;   //Ÿ�� �Ÿ�
    int closeDistIndex = 0;    //���� ����� �ε���
    public int TargetIndex = -1;      //Ÿ���� �� �ε���
    int prevTargetIndex = 0;
    public LayerMask layerMask;
    public float totalTime = 0f;
    public int monsterCount;

    public float atkSpd = 1f;

    public List<GameObject> MonsterList = new List<GameObject>();
    //Monster�� ��� List 

    public GameObject PlayerBolt;  //�߻�ü
    public Transform AttackPoint;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
    }

    private void Start()
    {
        _animator.CrossFade("Attack", atkSpd);

    }
    // Update is called once per frame
    void Update()
    {

        Attack();
    }

    void Attack()
    {
        if (!_animator.GetBool("IsRun"))
        {
            if (getATarget)
            {
                attackSpeed();
                transform.LookAt(AttackPoint.position);
            }
            else
            {
                attackSpeed();
            }

        }

    }
    void attackSpeed()
    {
        totalTime += Time.deltaTime;

        if (totalTime > atkSpd)
        {
            totalTime = 0f;
            Instantiate(PlayerBolt, AttackPoint.position, transform.rotation);
        }

    }
    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Monster"))
        {
            MonsterList.Add(other.gameObject); // ����
            Debug.Log("�� ī���� : " + monsterCount);
            getATarget = true;
            
        }
    }



    private void OnTriggerExit(Collider other)
    {

        getATarget = false;

    }





}
