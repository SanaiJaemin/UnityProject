using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : SingletonBehaviour<PlayerTarget>
{

    public bool getTarget = false;
    float currentDist = 0f;
    float closetDist = 100f;
    float TargetDist = 100f;
    int closeDistIndex = 0; // 가까운적 인덱스
    public int TargetIndex = -1;  // 타겟중일때 인덱스
    int prevIndex = 0; // 이전에 적의 인덱스
    float Totaltime;

    public float atkSpd = 1f;

    public List<GameObject> MonsterList = new List<GameObject>();

    public GameObject bulletPrefeb;
    public Transform firePosition;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
       
        
    }

    private void Start()
    {
        _animator.CrossFade("Attack", atkSpd);
    }



    private void Update()
    {
        setTarget();
        atkTarget();
    }

   void Attack()
    {
        
        Totaltime += Time.deltaTime;
        if(Totaltime > atkSpd)
        {
            Totaltime = 0f;
            Instantiate(bulletPrefeb, firePosition.position, transform.rotation);
        }
            
    }

    
    void setTarget()
    {
        if (MonsterList.Count != 0)
        {
            
            prevIndex = TargetIndex;
            currentDist = 0f;
            closeDistIndex = 0;
            TargetIndex = -1;
            for (int i = 0; i < MonsterList.Count; i++)
            {
                if (MonsterList[i] == null)
                {
                    return;
                }
                currentDist = Vector3.Distance(transform.position, MonsterList[i].transform.position);
                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, MonsterList[i].transform.position - transform.position, out hit, 20f);
                
                if (isHit && hit.transform.CompareTag("Monster"))
                {
                    if(TargetDist >= currentDist)
                    {
                        TargetIndex = i;

                        TargetDist = currentDist;
                        if(!_animator.GetBool("IsRun") && prevIndex != TargetIndex)
                        {
                            TargetIndex = prevIndex;
                        }
                    }

                }
                 
                if (closetDist >= currentDist)
                {
                    closeDistIndex = i;
                    closetDist = currentDist;
                    

                }
            
            }

            if(TargetIndex == -1)
            {
                TargetIndex = closeDistIndex;
                
            }

            closetDist = 100f;
            TargetDist = 100f;
            getTarget = true;
            Debug.Log("1");
        }
    }
    void atkTarget()
    {
        
        if(!_animator.GetBool("IsRun"))  
        {

            if (MonsterList.Count == 0 || TargetIndex == -1)
            { 
                return;
            }


            if (getTarget && MonsterList.Count != 0)
            {

                transform.LookAt(new Vector3(MonsterList[TargetIndex].transform.position.x, transform.position.y, MonsterList[TargetIndex].transform.position.z));
                Attack();

            }
           
           
        
        }

       
    }
}

  






