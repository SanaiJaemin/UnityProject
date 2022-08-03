using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{


    public GameObject EnemyCanvas;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            EnemyCanvas.GetComponent<EnemyHpBar>().currentHp -= 300f;
            
            
        }

    }

}
