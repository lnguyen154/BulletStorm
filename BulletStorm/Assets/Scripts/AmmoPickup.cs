using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int bulletsToAdd = 6;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with the ammo object
        if (other.CompareTag("Player"))
        {
            Debug.Log("tOUCJ");
            // Access the GunScript on the player or wherever the gun script is attached
            GunScript gunScript = other.GetComponentInChildren<GunScript>();

            if (gunScript != null)
            {
                // Add bullets to the gun
                gunScript.AddBullets(bulletsToAdd);

                // Destroy the ammo object after picking it up
                Destroy(gameObject);
            }
        }
    }
}
