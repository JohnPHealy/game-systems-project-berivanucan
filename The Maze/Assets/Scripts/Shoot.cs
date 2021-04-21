using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private bool collided;
    public GameObject explosionVFX;
    public float expDuration = 2f;
  


    void OnCollisionEnter(Collision co)
    {
        if(co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            Destroy(gameObject);
            Instantiate(explosionVFX, transform.position, transform.rotation);
            Destroy(gameObject, expDuration);
        }
    }
}
