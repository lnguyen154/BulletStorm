using UnityEngine;
using UnityEngine.AI;

public class PatrolChase : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    public Transform player;
    public float stoppingDistance;
    public float chaseRange = 10f;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        if (!isChasing)
        {
            agent.stoppingDistance = 0f;

            int newDestPoint = 0;
            do
            {
                newDestPoint = Random.Range(0, points.Length);
            } while (destPoint == newDestPoint);

            destPoint = newDestPoint;
            agent.destination = points[destPoint].position;
        }
    }

    void Update()
    {
        if (isChasing)
        {
            Debug.Log("Chasing");
            ChasePlayer();
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Debug.Log("Patrolling");
            GotoNextPoint();
        }
    }

    void ChasePlayer()
    {
        if (player != null)
        {
            agent.stoppingDistance = stoppingDistance;
            agent.destination = player.position;
        }
    }

    bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.position) <= range;
    }

    // Called when another collider enters the trigger area
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            // Player entered the trigger area, start chasing
            Debug.Log("Player entered trigger area");
            isChasing = true;
        }
    }

    // Called when another collider exits the trigger area
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exit: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            // Player exited the trigger area, resume patrolling
            Debug.Log("Player exited trigger area");
            isChasing = false;
            GotoNextPoint();
        }
    }
}
