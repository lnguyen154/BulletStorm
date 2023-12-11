using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform[] weapons;

    void Start()
    {
        DisableAllWeapons();
    }

    private void DisableAllWeapons()
    {
        foreach (Transform weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }

    // You can add more methods here for enabling specific weapons based on game logic if needed
}
