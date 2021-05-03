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

    public Transform point1, point2, point3, point4, point5, point6, point7, point8, point9, point10, point11, point12, point13, point14, point15;
    public NavMeshAgent navMeshAgent;
    public int currentTarget;
    private float distanceFromTarget;
    public Transform[] waypoints = null;
    
    private void Awake()
    {
       
        player = GameObject.FindWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        waypoints = new Transform[15] {point1, point2, point3, point4, point5, point6, point7, point8, point9, point10, point11, point12, point13, point14, point15};
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
}