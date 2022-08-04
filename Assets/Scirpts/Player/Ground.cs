using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private List<GameObject> MonsterListInRoom = new List<GameObject> ( );
    public bool playerInThisRoom = false;
    public bool isClearRoom = false;

    void Start()
    {

    }

    private void Update()
    {
        if(playerInThisRoom)
        {
            if(MonsterListInRoom.Count <= 0 && !isClearRoom)
            {
                isClearRoom = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monster"))
        {
            MonsterListInRoom.Add(other.gameObject);
            Debug.Log("몬스터 숫자 : " + MonsterListInRoom.Count);
        }
        if(other.CompareTag("Player"))
        {
            playerInThisRoom = true;
            PlayerTarget.Instance.MonsterList = new List<GameObject>(MonsterListInRoom);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInThisRoom = true;

        }

        if(other.CompareTag("Monster"))
        {
            MonsterListInRoom.Remove(other.gameObject);
        }
    }


}
