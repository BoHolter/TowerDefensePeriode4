using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
   
    public float range = 15f;
    public float fireRate = 1f;

    private float fireCountdown = 0f;

    void Update()
    {
        fireCountdown -= Time.deltaTime;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
    }

    void Shoot()
    {
        // Implement shooting logic
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(FindClosestEnemy());
        }
    }

    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            return nearestEnemy.transform;
        }

        return null;
    }
}

