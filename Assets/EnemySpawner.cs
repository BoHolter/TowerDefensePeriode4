using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject Enemy1Prefab;
    private float Enemy1Interval = 0.5f;
    [SerializeField]
    private GameObject Enemy2Prefab;
    private float Enemy2Interval = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(Enemy1Interval, Enemy1Prefab));
        StartCoroutine(spawnEnemy(Enemy2Interval, Enemy2Prefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    { 
        yield return new WaitForSeconds(interval);
        Vector3 pos = transform.position;
        GameObject newEnemy = Instantiate(enemy, pos , Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
    