using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : SingletonBehaviour<PlayerTarget>
{

    public bool getTarget = false;
    float currentDist = 0;
    float closetDist = 100;
    float TargetDist = 100f;
    int closeDistIndex = 0; // ������� �ε���
   public  int TargetIndex = -1;  // Ÿ�����϶� �ε���
    int prevIndex = 0; // ������ ���� �ε���
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
        _animator.CrossFade("attack", atkSpd);
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

        }
    }
    void atkTarget()
    {
        
        if(!_animator.GetBool("IsRun"))
            
        {

            if (getTarget && MonsterList.Count != 0)
            {
                transform.LookAt(new Vector3(MonsterList[TargetIndex].transform.position.x, transform.position.y, MonsterList[TargetIndex].transform.position.z));
                Attack();

            }
            else
                Attack();
        
        }

       
    }
}

  






