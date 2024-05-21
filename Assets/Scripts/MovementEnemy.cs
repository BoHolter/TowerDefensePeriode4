using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovementEnemy : MonoBehaviour
{
    public float Speed = 10f;
    private Transform target;
    private int wavepointindex = 0;

    void Start()
    {
        target = Waypointscript.Waypoints[0];
    }


    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoints();
        }
    }
    void GetNextWaypoints()
    {
        if(wavepointindex >= Waypointscript.Waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointindex++;
        target = Waypointscript.Waypoints[wavepointindex];
    }
}
    
