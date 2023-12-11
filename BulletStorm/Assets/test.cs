using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{
    public NavMeshAgent enemy;
    private float bulletTime;

    [SerializeField] private float timer;

    private void Start()
    {
        lastShootTime = Time.time;
    }
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < shootingRange && Time.time - lastShootTime > shootingCooldown)
        {
            ShootPlayer();
            lastShootTime = Time.time;
        }
    }

    private void ShootPlayer()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bulletRig = bullet.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * eneimySpeed);


        Destroy(bullet, 3f);
 
    }
}
