using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Shootingscript : MonoBehaviour
{
    public NavMeshAgent Tower;
    public Transform Enemy;

    [SerializeField] private float timer = 5;
    private float bulletTime;

    public GameObject TowerBullet;
    public Transform spawnPoint;
    public float enemySpeed;

    void Update()
    {
        Tower.SetDestination(Enemy.position);
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime < 0) return;
        bulletTime = timer;

        GameObject bulletObj = Instantiate(TowerBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody BulletRig = bulletObj.GetComponent<Rigidbody>();
        BulletRig.AddForce(BulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 0.1f);
    }

}
