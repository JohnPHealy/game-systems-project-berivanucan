using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Symbol")
        {
            Debug.Log("collided");
            Animator anim = gameObject.GetComponent<Animator>();
            anim.SetTrigger("OpenDoor");
        }
        
    }
}
