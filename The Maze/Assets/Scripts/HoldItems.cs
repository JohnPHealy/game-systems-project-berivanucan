using UnityEngine;
 using System.Collections;
 
 public class HoldItems : MonoBehaviour 
 {
    public float pickUpRange = 5;
    public Transform holdParent;
    public float moveForce = 250;
    private GameObject heldObj;

 void Update()
 {
    if(Input.GetKeyDown(KeyCode.E))
    {
        if(heldObj == null)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, pickUpRange))
            {
                pickUpObject(hit.transform.gameObject);
            }
        }

        else
        {
            DropObject();
        }
    }

    if(heldObj != null)
    {
        MoveObject();
    }
 }

 void MoveObject()
 {
    if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
    {
        Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
        heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
    }
 }

 void pickUpObject(GameObject pickObj)
 {
    if(pickObj.GetComponent<Rigidbody>())
    {
        Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
        objRig.useGravity = false;
        objRig.drag = 10;

        objRig.transform.parent = holdParent;
        heldObj = pickObj;
    }
 }

 void DropObject()
 {
    Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
    heldRig.useGravity = true;
    heldRig.drag = 1;

    heldObj.transform.parent = null;
    heldObj = null;
 }
    
 }
