using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy1Prefab;
    private float Enemy1Interval = 3.5f;
 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(Enemy1Interval, Enemy1Prefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    { 
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
    