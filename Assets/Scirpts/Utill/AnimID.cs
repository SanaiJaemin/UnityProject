using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public static class PlayerAnimID
    {
        public static readonly int Die = Animator.StringToHash("Die");
        public static readonly int Reload = Animator.StringToHash("Reload");
        public static readonly int Move = Animator.StringToHash("Move");
    }

    public static class ZombieAnimID
    {
        public static readonly int Die = PlayerAnimID.Die;
        public static readonly int HasTarget = Animator.StringToHash("HasTarget");
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
