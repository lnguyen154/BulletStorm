using UnityEngine;

public class GrenadePickup : MonoBehaviour
{
    public int grenadeToAdd = 1;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with the ammo object
        if (other.CompareTag("Player"))
        {
            // Access the GunScript on the player or wherever the gun script is attached
            RPGScript rpgScript = other.GetComponentInChildren<RPGScript>();

            if (rpgScript != null)
            {
                // Add bullets to the gun
                rpgScript.AddGrenade(grenadeToAdd);

                // Destroy the ammo object after picking it up
                Destroy(gameObject);
            }
        }
    }
}
