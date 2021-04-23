using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class GuideAI : MonoBehaviour
{
    // General state machine variables
    public GameObject player;
    private Animator animator;
    private Ray ray;
    private RaycastHit hit;
    private float maxDistanceToCheck = 6.0f;
    private float currentDistance;
    private Vector3 checkDirection;
    // Patrol state variables
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public Transform point5;
    public Transform point6;
    public Transform point7;
    public Transform point8;
    public Transform point9;
    public Transform point10;
    public Transform point11;
    public Transform point12;
    public Transform point13;
    public Transform point14;
    public Transform point15;
    public NavMeshAgent navMeshAgent;
    public int currentTarget;
    private float distanceFromTarget;
    public Transform[] waypoints = null;
    public int maxHealth = 100;
    int currentHealth;
    private void Awake()
    {
        currentHealth = maxHealth;
        player = GameObject.FindWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        waypoints = new Transform[15] {
point1,
point2, 
point3,
point4,
point5,
point6,
point7,
point8,
point9,
point10,
point11,
point12,
point13,
point14,
point15
        };
        currentTarget = 0;
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }
    private void FixedUpdate()
    {
        //First we check distance from the player
        currentDistance = Vector3.Distance(player.transform.position,
        transform.position);
        animator.SetFloat("playerDistance", currentDistance);
        //Then we check for visibility
        checkDirection = player.transform.position - transform.position;
        ray = new Ray(transform.position, checkDirection);
        if (Physics.Raycast(ray, out hit, maxDistanceToCheck))
        {
            if (hit.collider.gameObject == player)
            {
                animator.SetBool("isPlayerVisible", true);
            }
            else
            {
                animator.SetBool("isPlayerVisible", false);
            }
        }
        else
        {
            animator.SetBool("isPlayerVisible", false);
        }
        //Lastly, we get the distance to the next waypoint target
        distanceFromTarget =
        Vector3.Distance(waypoints[currentTarget].position, transform.position);
        animator.SetFloat("distanceFromPoint", distanceFromTarget);
    }

    public void SetNextPoint()
    {
        
        switch (currentTarget)
        {
            case 0:
                currentTarget = 1;
                break;
            case 1:
                currentTarget = 2;
                break;
            case 2:
                currentTarget = 3;
                break;
            case 3:
                currentTarget = 4;
                break;
            case 4:
                currentTarget = 5;
                break;
            case 5:
                currentTarget = 6;
                break;
            case 6:
                currentTarget = 7;
                break;
            case 7:
                currentTarget = 8;
                break;
            case 8:
                currentTarget = 9;
                break;
            case 9:
                currentTarget = 10;
                break;
            case 10:
                currentTarget = 11;
                break;
            case 11:
                currentTarget = 12;
                break;
            case 12:
                currentTarget = 13;
                break;
            case 13:
                currentTarget = 14;
                break;
            case 14:
                currentTarget = 15;
                break;
            case 15:
                currentTarget = 15;
                break;

        }
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }

    public void FindPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        animator.SetBool("isDead", true);

        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 2);
        this.enabled = false;

    }
}