using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class RobotShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 5f; 
    public float fireRate = 1.5f; 

    private float nextFireTime = 0f;

    void Awake()
    {
        ValidateFirePoint(); 
    }

    void Start()
    {
        ValidateFirePoint(); 
    }

    void Update()
    {

        if (firePoint == null)
        {
            Debug.LogError("❌ FirePoint is null in Update()");
            ValidateFirePoint();
        }
        else if (!firePoint.gameObject.activeInHierarchy)
        {
            Debug.LogError("⚠ FirePoint is there");
            firePoint.gameObject.SetActive(true);
        }

        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void ValidateFirePoint()
    {
        if (firePoint == null)
        {
            firePoint = transform.Find("FirePoint");
        }

        if (firePoint == null)
        {
            Debug.LogError("❌ cannot find firepoint");
        }
        else
        {
            Debug.Log("✅ FirePoint: " + firePoint.position);
        }
    }

    void Shoot()
    {
        if (firePoint == null)
        {
            Debug.LogError("❌ FirePoint is null in Shoot()");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = Vector2.right * bulletSpeed; 
        }

        Destroy(bullet, 3f); 
    }

    void OnDestroy()
    {
        Debug.LogError("⚠ `Robot` is destroy！", this);
        Debug.LogError("🔥 possible destroy reason：" + System.Environment.StackTrace);
    }


}

