using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCollection : MonoBehaviour {

    public Zone[] Waypoints;

    private void Awake() {

        Waypoints = transform.GetComponentsInChildren<Zone>();


    }

    public Zone RequestZone(Need need)
    {
        for (int i = 0; i < Waypoints.Length; i++)
        {
            if ((int)Waypoints[i].zoneActivity == (int)need)
            {
                return Waypoints[i];
            }
        }

        return null;
    }

}
