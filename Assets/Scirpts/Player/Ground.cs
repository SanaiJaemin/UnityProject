using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public List<GameObject> MonsterListInRoom = new List<GameObject> ( );
    PlayerTarget _playerTarget;
    
    public bool playerInThisRoom = false;
    public bool isClearRoom = false;

    GameObject Nextgate;
    
    // Start is called before the first frame update
    void Start ( )
    {
        
    }

    // Update is called once per frame
    void Update ( )
    {
        if ( playerInThisRoom )
        {
            if ( PlayerTarget.Instance.MonsterList.Count <= 0 && !isClearRoom )
            {
                isClearRoom = true;
                Debug.Log ( " Clear " );
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            MonsterListInRoom.Add(other.gameObject); // 변경
            Debug.Log(" Mob name : " + other.gameObject); // 변경
        }
        if (other.CompareTag("Player"))
        {
            //플레이어가 방에 들어오면 이방의 몹리스트를 링크(복사)시킨다.
            playerInThisRoom = true;
            PlayerTarget.Instance.MonsterList = new List<GameObject>(MonsterListInRoom);
            Debug.Log("Enter New Room! Mob Count : " + PlayerTarget.Instance.MonsterList.Count);

      
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInThisRoom = false;
            
            Debug.Log("Player Exit!");
        }
        if (other.CompareTag("Monster"))
        {
            MonsterListInRoom.Remove(other.gameObject);  // 변경
        }
    }


}
