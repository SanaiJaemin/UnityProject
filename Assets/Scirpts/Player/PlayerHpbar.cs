using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHpbar : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Player;
    public Slider HpBar;
    public float Maxhp;
    public float currentHp;
    

    
    public Slider ExpBar;
    public float currentExp;
    public float MaxExp;
    public GameObject ExpBarLine;
    

     void Awake()
    {
           
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.position.x, 1.5f, Player.position.z);
        HpBar.value = currentHp / Maxhp;
      
      

        

    }

 
}
