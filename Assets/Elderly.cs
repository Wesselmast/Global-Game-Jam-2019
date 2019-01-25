using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Elderly : MonoBehaviour {

    public WaypointCollection waypoints;
    public float speed;

    private NavMeshAgent nav;
    private Transform targetWaypoint;

	void Start () {

        nav = GetComponent<NavMeshAgent>();
        targetWaypoint = waypoints.waypoints[Random.Range(0, waypoints.waypoints.Length - 1)];
        nav.speed = speed;

    }
	

	void Update () {

        if(Vector2.Distance(new Vector2(transform.position.x,transform.position.z),new Vector2(targetWaypoint.position.x,targetWaypoint.position.z)) < 0.3f)
        {
            targetWaypoint = waypoints.waypoints[Random.Range(0, waypoints.waypoints.Length - 1)];
        }

        nav.destination = targetWaypoint.position;
		
	}
}
