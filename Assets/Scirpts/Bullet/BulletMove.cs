using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 20f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Wall") || other.transform.CompareTag("Monster"))
        {
            //벽또는 몬스터에 닿았을때
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall") || collision.transform.CompareTag("Monster"))
        {
            //벽또는 몬스터에 닿았을때
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

