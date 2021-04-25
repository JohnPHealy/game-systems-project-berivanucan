using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject instructions;
    public GameObject Closeinstructions;

    public GameObject portalEffect;
    public bool isEnabled = false;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && isEnabled)
        {
            portalEffect.SetActive(true);
            isEnabled = false;
            instructions.SetActive(false);
            Closeinstructions.SetActive(true);

        }
        else if(Input.GetKeyDown(KeyCode.E) && !isEnabled)
        {
            portalEffect.SetActive(false);
            isEnabled = true;
            instructions.SetActive(true);
            Closeinstructions.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
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
    }
}
