// Patrol.cs
using UnityEngine;
using UnityEngine.AI;

public class navigation_patrol : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    public Transform player; //Reference to the player
    public float detectionRange = 10f;
    public float attackRange = 5f;
    public float stoppingDistance;
    public Collider attackCollider;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();

        // Ensure the attack collider is initially disabled
        if (attackCollider != null)
        {
            attackCollider.enabled = false;
        }
    }


    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;

        int newDestPoint = 0;
        do
        {
            newDestPoint = Random.Range(0, points.Length);
        } while (destPoint == newDestPoint);

        destPoint = newDestPoint;
    }


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        //InstantlyTurn(agent.destination);
        if (distanceToPlayer < detectionRange)
        {
            // Player detected, chase the player
            ChasePlayer();
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }

    private void ChasePlayer()
    {
        agent.stoppingDistance = stoppingDistance; // Set stopping distance for chasing
        agent.isStopped = false;
        agent.destination = player.position;
    }
}
