using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool IsWalking = animator.GetBool("IsWalking");
        bool forwardPressed = Input.GetKey("m");
        
        if(!IsWalking && forwardPressed)
        {
            animator.SetBool("IsWalking", true);
        }

        if (IsWalking && !forwardPressed)
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
