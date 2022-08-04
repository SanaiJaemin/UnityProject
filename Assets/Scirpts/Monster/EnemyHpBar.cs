using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHpBar : MonoBehaviour
{
    public Transform Enemy;
    public Slider HpBar;
    public float currentHp = 1000f;
    public float maxHp = 1000f;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Enemy.position.x, 3f, Enemy.position.z);
        HpBar.value = Mathf.Lerp(HpBar.value, currentHp / maxHp, Time.deltaTime); //선형보간함수 이쁘게 보임
        if (HpBar == null)
        {
            return;
        
        }
        if(HpBar.value == 0)
        {
            HpBar.gameObject.SetActive(false);
        }
       
    }

    
}
