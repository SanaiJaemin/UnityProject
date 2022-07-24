using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    public bool playerIs = false;
    public List<GameObject> MonsterInRoom = new List<GameObject>();
    public static PlayerTarget instance;
    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag == "Monster")
        //{
        //    MonsterInRoom.Add(other.gameObject);
        //}
        
        //if(other.gameObject.tag == "Player")
        //{
        //    Player
        //}
    
    }

   


    private void Awake()
    {
         
    }
    private void Update()
    {
        
    }
}
