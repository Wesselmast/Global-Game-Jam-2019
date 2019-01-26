using System;
using UnityEngine;
using UnityEngine.AI;

public enum TargetPriority {
    HIGH,
    MEDIUM,
    LOW
}

[RequireComponent(typeof(NavMeshAgent))]
public class Elderly : MonoBehaviour {

    [SerializeField] private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    private Transform target;
    private NavMeshAgent nav;
    private Transform targetWaypoint;
    private bool roam = true;
    private WaypointCollection waypoints;

    private void Awake() {
        nav = GetComponent<NavMeshAgent>();
        waypoints = FindObjectOfType<WaypointCollection>();
    }

    private void Start () {
        targetWaypoint = waypoints.Waypoints[UnityEngine.Random.Range(0, waypoints.Waypoints.Length - 1)];
    }
     
    private void FixedUpdate() {
        if(target != null) DetermineMovement(target);
        else nav.destination = Roam().position;
        nav.speed = speed;
    }

    private Transform Roam() {
        if(Vector2.Distance(new Vector2(transform.position.x,transform.position.z),
                            new Vector2(targetWaypoint.position.x,targetWaypoint.position.z)) < 0.3f) {
            targetWaypoint = waypoints.Waypoints[UnityEngine.Random.Range(0, waypoints.Waypoints.Length - 1)];
        }
        return targetWaypoint;
    }

    private void DetermineMovement(Transform target) {
        try {
            if (target.GetComponent<NurseInput>().SelectElder) roam = !roam;
            if (!roam) nav.destination = target.position;
            else { nav.destination = Roam().position; this.target = null; }
        } catch { }
        this.target = null;
    }

    public void SetTarget(Transform target, TargetPriority prio) {
        if (prio == TargetPriority.HIGH) { this.target = target; return; }
        else if (prio == TargetPriority.MEDIUM) { this.target = target; return; }
        else if (prio == TargetPriority.LOW) { this.target = target; return; }
    }
}