using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerscript : MonoBehaviour
{
    private Transform target;

    public float Range = 15f;
    public string enemytag = "Enemy";

    public float firerate = 1f;
    public float firecountdown = 0f;
    public GameObject Bullet;
    public Transform firePoint;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestenemy = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);

        foreach (GameObject enemy in enemies)
        {
            float DistanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(DistanceToEnemy < shortestDistance)
            {
                shortestDistance = DistanceToEnemy;
                nearestenemy = enemy;

            }

        }
        if(nearestenemy != null && shortestDistance <= Range)
        {
            target = nearestenemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

   
    void Update()
    {
        if (target == null)
            return;
        if (firecountdown <= 0f)
        {
            Shoot();
            firecountdown = 1f / firerate;
        }
        firecountdown -= Time.deltaTime;
    }
    void Shoot()
    {
        GameObject BulletGo = (GameObject)Instantiate(Bullet, firePoint.position, firePoint.rotation);
        Bulletscript bullet = BulletGo.GetComponent<Bulletscript>();
        if (bullet != null)
            bullet.Seek(target);
    }
}
