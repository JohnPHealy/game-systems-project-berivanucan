using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fireball : MonoBehaviour
{
    public Camera cam;
    private Vector3 destination;
    public GameObject fireball; 
    public Transform LHFirePoint, RHFirePoint; 
    private bool leftHand;
    private Transform firePoint;
    public float fireballSpeed = 30f;
    public Rigidbody rb;
    public float arcRange = 1f;
    public AudioSource shootAudio;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        
        {
            ShootFireball();
            shootAudio.Play();
        }
    }

    void ShootFireball(){

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)) 

            destination = hit.point; 
         else 
            destination = ray.GetPoint(1000);
        
        if(leftHand) {
            leftHand = false;
            InstantiateFireball(LHFirePoint);

            } else {
                leftHand = true;
                InstantiateFireball(RHFirePoint);
            }

    }

    void InstantiateFireball (Transform firePoint) {

        var fireballObj = Instantiate (fireball, firePoint.position, Quaternion.identity) as GameObject;

        fireballObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * fireballSpeed;
        iTween.PunchPosition(fireballObj, new Vector3 (Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange),0), Random.Range(0.5f, 2f)); 
    }
    
}
