using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    public GameObject bulletPreweb; //�Ѿ�
    public GameObject Target;
    private int monsterCount;
    public float bulletCoolTime; 
    
    private Animator _animator;
    private float fullTime = 0.5f;
    private bool targetConfirmation = false;
    private bool isRun = false;


     void Awake()
    {
        
        _animator = GetComponent<Animator>();
    }
     void Update()
    {


        if (_animator.GetBool("IsRun")) //  ���� �ƴҶ��� �߽�
        {
            isRun = true;

        }
        else
            isRun = false;
         
       
       if(isRun == false)
        {
            if (targetConfirmation)
            {
                if(Target != null)
                transform.LookAt(Target.transform.position);
                bulletShot();
            }
            else
            {

                Target = null;
            
                bulletShot();
            
            }
           
        }

    }

    void bulletShot() //�߻�
    {
        fullTime += Time.deltaTime;
        if (fullTime > bulletCoolTime)
        {
            fullTime = 0f;
            GameObject bullet = Instantiate(bulletPreweb, transform.position, transform.rotation);
            
        }
    }

    private void OnTriggerStay(Collider other) //���� �߽߰� Ÿ������
    {
        if (other.tag == "Monster")
        {
            Debug.Log($"���͸� �������ϴ�.");
            Target = other.gameObject;
            Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.red); //������
            targetConfirmation = true;
        }
        
       
    }

    private void OnTriggerExit(Collider other)
    {
        targetConfirmation = false;
    }








}
