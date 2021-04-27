using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalController : MonoBehaviour
{
    public GameObject instructions;
    public GameObject Closeinstructions;

    public GameObject portalEffect;
    public bool isEnabled = false;
    public bool canClose= false;
    public float distanceFromTarget;
    public GameObject portal;

    void Update()
    {

        distanceFromTarget =
       Vector3.Distance(portal.transform.position, transform.position);

        if (Input.GetKeyDown(KeyCode.E) && isEnabled)
        {
            portalEffect.SetActive(true);
            isEnabled = false;
            canClose = true;
            instructions.SetActive(false);
            Closeinstructions.SetActive(true);

        }
        else if(Input.GetKeyDown(KeyCode.E) && canClose)
        {
            portalEffect.SetActive(false);
            isEnabled = true;
            canClose = false;
            instructions.SetActive(true);
            Closeinstructions.SetActive(false);
        }

        if(distanceFromTarget <= 5f && !canClose)
        {
            isEnabled = true;
            instructions.SetActive(true);
            isEnabled = true;
        }


        if (distanceFromTarget > 5f)
        {
            
            instructions.SetActive(false);
            Closeinstructions.SetActive(false);
        }

        if (distanceFromTarget <= 2f && canClose)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Portal")
        {
            instructions.SetActive(true);
            isEnabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Portal")
        {
            instructions.SetActive(false);
            Closeinstructions.SetActive(false);
        }
    }*/
}
