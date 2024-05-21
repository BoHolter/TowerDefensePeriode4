using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointscript : MonoBehaviour
{
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
