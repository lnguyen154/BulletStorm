using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Adjust the damage value as needed

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Assuming there's a PlayerHealth script on the player GameObject
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Apply damage to the player
                playerHealth.TakeDamage(damage);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
