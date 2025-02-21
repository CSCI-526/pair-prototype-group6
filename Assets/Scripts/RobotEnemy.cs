using UnityEngine;

public class RobotEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; // Assign a position for bullet spawn
    public float fireRate = 1.5f; // Time between shots
    private float nextFireTime;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Set next fire time
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        RoboBullet bulletScript = bullet.GetComponent<RoboBullet>();
        
        // Flip direction based on enemy facing direction
        bulletScript.direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
    }
}