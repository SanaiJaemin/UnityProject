using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
   
    private float fullTime = 0f;
    public float bulletCoolTime;
    private float bulletDeleteTime;

     void Awake()
    {

    }
     void Update()
    {
        bulletShotOn();

    }

    void bulletShotOn()
    {
        fullTime += Time.deltaTime;
        if (fullTime > bulletCoolTime)
        {
            fullTime = 0f;
            GameObject bullet = Instantiate(bulletPreweb, transform.position, transform.rotation);
            transform.LookAt(Target.transform.position);
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Monster")
        {


            Target = other.gameObject;
            Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.red);

        }
    }
   
}
