﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 10;
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
        if(other.gameObject.tag=="Monster")
            {
                Debug.Log("take damage");
                TakeDamage(1);
            }
        
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;



        if (currentHealth <= 0)
        {
     
            Die();
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