using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 30;
    public int currentHealth;
    public bool canHurt;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log("simoneeeeeee!");
            TakeDamage(1);
        }

    }
    public void OnCollisionExit(Collision other)
    {
        
        if (other.gameObject.CompareTag("Monster"))
            {
                Debug.Log("exit collide");
                other.gameObject.GetComponent<Monster_AI>().TakeDamage(10);
                TakeDamage(1);
               
            }
        
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;



        if (currentHealth <= 0)
        {
     
            Die();
            Destroy(gameObject, 3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    public void Heal(string heal)
    {
        Debug.Log("Before Switch");
        switch (heal)
        {
            case "BluePotion":
                {
                    currentHealth += 1;
                    Debug.Log("After Switch");
                }
                break;
            case "GreenPotion":
                {
                    currentHealth += 3;
                    Debug.Log("After Switch");
                }
                break;
            case "PurplePotion":
                {
                    currentHealth += 2;
                    Debug.Log("After Switch");
                }
                break;
            case "RedPotion":
                {
                    currentHealth += 4;
                    Debug.Log("After Switch");
                }
                break;
            case "YellowPotion":
                {
                    currentHealth += 1;
                    Debug.Log("After Switch");
                }
                break;

        }


        if (currentHealth <= maxHealth)
        {

        }
    }


    public void Die()
    {
        Debug.Log("player died");
      

        Invoke("ReturnMenu", 2f);

        GetComponent<Collider>().enabled = false;

    }
}
