using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
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

    public void ChasePlayer()
    {
        if (player != null)
        {
            agent.stoppingDistance = stoppingDistance;
            agent.destination = player.position;
        }
    }
    public void StopChasingPlayer()
    {
        isChasing = false;
        agent.stoppingDistance = 0f;
        GotoNextPoint(); // Go back to patrolling
    }

    bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.position) <= range;
    }

}
