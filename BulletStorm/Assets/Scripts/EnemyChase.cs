using System.Security.Cryptography;
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

    public float shootingRange = 5f;
    public float shootingCooldown = 1f;
    private float lastShotTime;
    public float bulletSpeed;

    public GameObject bulletPrefab;
    public Transform firePoint;

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
        if (IsPlayerInRange(shootingRange))
        {
            // Check if enough time has passed since the last shot
            if (Time.time - lastShotTime > shootingCooldown)
            {
                // Start shooting
                Shoot();
                lastShotTime = Time.time;
            }
        }
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

    private void Shoot()
    {
        // Instantiate a bullet prefab at the firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = firePoint.forward * bulletSpeed; // Adjust bulletSpeed for the desired velocity

        Destroy(bullet, 2f);
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
