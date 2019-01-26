using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityZone : MonoBehaviour {
    [SerializeField] private Need need;
    [SerializeField] private float restoreAmt;
    [SerializeField] private float needDowntime;

    private bool firstIter = true;

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Elder") {
            Interest interest = other.GetComponent<Interest>();
            if (interest.CurrentNeed == need) {
                if (firstIter) {
                    StartCoroutine(Counter(interest));
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