using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityZone : MonoBehaviour {
    [SerializeField] private Need need;
    [SerializeField] private float restoreAmt;
    [SerializeField] private float needDowntime;

    //private Transform[] waypoints;
    private bool firstIter = true;

    private void Awake() {
        //waypoints = GetComponentsInChildren<Transform>();
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Elder") {
            Interest interest = other.GetComponent<Interest>();
            if (interest.CurrentNeed == need) {
                if (firstIter) {
                    Debug.Log(other.name + ": I am restoring my mood!");
                    StartCoroutine(Counter(interest));
                    //other.GetComponent<Elderly>().SetTarget(waypoints[Random.Range(0, waypoints.Length - 1)], TargetPriority.LOW);
                    firstIter = false;
                }
                interest.Homefulness += interest.HomefulnessReduction + restoreAmt;
            }
        }
    }

    IEnumerator Counter(Interest i) {
        yield return new WaitForSeconds(needDowntime);
        i.CurrentNeed = Need.None;
    }
}