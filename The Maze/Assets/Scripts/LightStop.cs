using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStop : MonoBehaviour
{
    private bool collided = false;
    
    public Rigidbody lightRB;

    void Start()
    {
    lightRB = gameObject.GetComponent<Rigidbody>();
    }


    void OnCollisionEnter(Collision co)
    {
        if(co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            Debug.Log("I collided");
           
            lightRB.velocity = new Vector3(0, 0, 0);
            lightRB.angularVelocity = new Vector3(0, 0, 0);
        }
    }
}
