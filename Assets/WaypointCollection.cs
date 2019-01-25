using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCollection : MonoBehaviour {

    //[HideInInspector]
    public Transform[] waypoints;

    private void Awake()
    {
        waypoints = transform.GetComponentsInChildren<Transform>();
    }

}
