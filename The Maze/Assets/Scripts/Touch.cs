using UnityEngine;
public class Touch : Sense
{
    void OnTriggerEnter(Collider other)
    {
        
        if (gameObject.CompareTag("Player") || gameObject.CompareTag("Fireball"))
        {
            
        }
    }
}
