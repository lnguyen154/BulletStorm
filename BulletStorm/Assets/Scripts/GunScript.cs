using System;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public int maxBullets = 6; //Max number of bullets
    private int currentBullet; // Current number of bullets

    public GameObject impactFX;

    public GameObject bulletPrefab;
    public Transform bulletPoint;

    public ParticleSystem muzzleFlash;

    public Camera fpsCam;

    private void Start()
    {
        currentBullet = maxBullets; // Initialze the current bullets 
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
        return currentBullet > 0;
    }

    private void Shoot()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
        currentBullet--;
        Debug.Log(currentBullet.ToString());
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            EnemyDamage target= hit.transform.GetComponent<EnemyDamage>();

            if (target != null) 
            {
                target.TakeDamage(damage);
            }
            Destroy(bullet, .5f);
            Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
    public void AddBullets(int bulletsToAdd)
    {
        // Calculate the new total number of bullets
        int totalBullets = currentBullet + bulletsToAdd;

        // Ensure the total does not exceed the maximum
        currentBullet = Mathf.Min(totalBullets, maxBullets);
    }
}
