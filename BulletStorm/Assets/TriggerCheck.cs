// Example script in C# for Unity

using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    // Reference to the enemy or enemies that will chase the player
    public GameObject[] enemies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            Debug.Log("Trigger");
            // Player has entered the trigger zone
            StartChasing();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            // Player has left the trigger zone
            StopChasing();
        }
    }

    private void StartChasing()
    {
        foreach (GameObject enemy in enemies)
        {
            // Implement code to make the enemy chase the player
            enemy.GetComponent<EnemyChase>().ChasePlayer();
        }
    }

    private void StopChasing()
    {
        foreach (GameObject enemy in enemies)
        {
            // Implement code to stop the enemy from chasing the player
            enemy.GetComponent<EnemyChase>().StopChasingPlayer();   
        }
    }
}
