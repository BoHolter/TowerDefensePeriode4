using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointscript : MonoBehaviour
{
    // Start is called before the first frame update
    public static Transform[] Waypoints;

    private void Awake()
    {
        Waypoints = new Transform[transform.childCount];
        for (int i = 0; i < Waypoints.Length; i++)
        {

            Waypoints[i] = transform.GetChild(i);
        }
    }
}
