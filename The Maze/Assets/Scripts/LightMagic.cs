using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightMagic : MonoBehaviour
{
   public Camera cam;
    private Vector3 destination;
    public GameObject projectile; 
    public Transform LHFirePoint, RHFirePoint; 
    private bool leftHand;
    private Transform firePoint;
    public float projectileSpeed = 30f;
    public Rigidbody rb;
    public float arcRange = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        
        {
            ShootProjectile();
        }
    }

    void ShootProjectile(){

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)) 

            destination = hit.point; 
         else 
            destination = ray.GetPoint(100);
        
        if(leftHand) {
            leftHand = false;
            InstantiateProjectile(RHFirePoint);

            } else {
                leftHand = true;
                
            }

        
    }

    void InstantiateProjectile (Transform firePoint) {

        var projectileObj = Instantiate (projectile, firePoint.position, Quaternion.identity) as GameObject;

        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
        iTween.PunchPosition(projectileObj, new Vector3 (Random.Range(-arcRange, arcRange), Random.Range(-arcRange, arcRange),0), Random.Range(0.5f, 2f)); 
    }
    
}
