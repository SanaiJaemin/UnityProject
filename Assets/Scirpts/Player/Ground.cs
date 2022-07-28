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
            MonsterListInRoom.Add(other.gameObject); // ����
            Debug.Log(" Mob name : " + other.gameObject); // ����
        }
        if (other.CompareTag("Player"))
        {
            //�÷��̾ �濡 ������ �̹��� ������Ʈ�� ��ũ(����)��Ų��.
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
            MonsterListInRoom.Remove(other.gameObject);  // ����
        }
    }


}
