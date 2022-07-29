using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : EnemyBase
{

   public enum State
    {
        Idle,
        Run,
        Attack
    };

    public State currentState = State.Idle;

    // Start is called before the first frame update
    //protected void Start()
    //{
    //    base.Start();

        
    //}

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
