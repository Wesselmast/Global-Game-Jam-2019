using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCollection : MonoBehaviour {

    public Transform[] Waypoints { get; private set; }

    private void Awake() {
        Waypoints = transform.GetComponentsInChildren<Transform>();
    }

}
