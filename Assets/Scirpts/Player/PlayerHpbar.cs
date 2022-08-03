using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHpBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Player;
    public Slider HpBar;
    public float Maxhp;
    public float currentHp;
    public GameObject HpBarLine;
    float unitHp = 200f;

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
