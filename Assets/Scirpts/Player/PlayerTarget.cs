using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    public GameObject bulletPreweb; //총알
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


        if (_animator.GetBool("IsRun")) //  런이 아닐때만 발싸
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

    void bulletShot() //발사
    {
        fullTime += Time.deltaTime;
        if (fullTime > bulletCoolTime)
        {
            fullTime = 0f;
            GameObject bullet = Instantiate(bulletPreweb, transform.position, transform.rotation);
            
        }
    }

    private void OnTriggerStay(Collider other) //몬스터 발견시 타켓지정
    {
        if (other.tag == "Monster")
        {
            Debug.Log($"몬스터를 만났습니다.");
            Target = other.gameObject;
            Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.red); //렌더링
            targetConfirmation = true;
        }
        
       
    }

    private void OnTriggerExit(Collider other)
    {
        targetConfirmation = false;
    }








}
