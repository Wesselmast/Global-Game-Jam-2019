using UnityEngine;

[RequireComponent(typeof(NurseInput))]
public class FindElderly : MonoBehaviour {

    public float radius;

    [SerializeField] private LayerMask elderlyMask;

    private void FixedUpdate() {
        Elderly closestElder = GetClosestElder(Physics.OverlapSphere(transform.position, radius, elderlyMask));
        if (!ReferenceEquals(closestElder, null)) closestElder.SetTarget(transform, TargetPriority.MEDIUM);
        else foreach (var elder in FindObjectsOfType<Elderly>()) elder.SetTarget(null, TargetPriority.MEDIUM);
    }

    private Elderly GetClosestElder(Collider[] elderlyPeople) {
        Transform closest = null;
        float bestDist = float.MaxValue;
        for (int i = 0; i < elderlyPeople.Length; i++) {
            float thisDist = Vector3.Distance(transform.position, elderlyPeople[i].transform.position);
            if (thisDist < bestDist) {
                closest = elderlyPeople[i].transform;
                bestDist = thisDist;
            }
        }
        try { return closest.GetComponent<Elderly>(); }
        catch { return null; }
    }
}
