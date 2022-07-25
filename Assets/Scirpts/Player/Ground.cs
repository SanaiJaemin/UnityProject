using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool playerIs = false;
    public List<GameObject> MonsterCount = new List<GameObject>();
    public static Ground Instance;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Monster")
        {
            MonsterCount.Add(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
