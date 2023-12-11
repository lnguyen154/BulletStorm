using System;
using UnityEngine;

public class RPGScript : MonoBehaviour
{
    public float damage = 50f;
    public float range = 100f;
    public int maxGrenade = 6; //Max number of grenade
    private int currentGrenade; // Current number of grenade

    private AudioSource explodingSound;

    public GameObject impactFX;

    public GameObject grenadePrefab;
    public Transform RPGPoint;

    public ParticleSystem muzzleFlash;

    public Camera fpsCam;

    private void Start()
    {
        currentGrenade = maxGrenade; // Initialize the current grenade

        explodingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && CanShoot())
        {
            Shoot();
        }
    }

    private bool CanShoot()
    {
        return currentGrenade > 0;
    }

    private void Shoot()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
        currentGrenade--;
        if (explodingSound != null)
        {
            explodingSound.Play();
        }
        Debug.Log(currentGrenade.ToString());
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            GameObject bullet = Instantiate(grenadePrefab, RPGPoint.position, RPGPoint.rotation);
            EnemyDamage target = hit.transform.GetComponent<EnemyDamage>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
            Destroy(bullet, .5f);
            Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
    public void AddGrenade(int bulletsToAdd)
    {
        // Calculate the new total number of bullets
        int totalGrenade = currentGrenade + bulletsToAdd;

        // Ensure the total does not exceed the maximum
        currentGrenade = Mathf.Min(totalGrenade, maxGrenade);
    }
}
