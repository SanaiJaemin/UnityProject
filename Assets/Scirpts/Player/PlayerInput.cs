using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
  
    public float MoveDirection { get; private set; }
    public float Rotate { get; private set; }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveDirection = Input.GetAxis("Vertical"); //Ű�Է�
        Rotate = Input.GetAxis("Horizontal"); //Ű�Է�
        
    }
}
