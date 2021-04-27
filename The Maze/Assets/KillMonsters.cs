using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMonsters : MonoBehaviour
{
    public void OnCollisionExit(Collision other)
    {

        if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log("Hit that wanna be Org!");
            other.gameObject.GetComponent<Monster_AI>().TakeDamage(10);


        }

    }
}
