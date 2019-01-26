using UnityEngine;

[RequireComponent(typeof(NurseInput))]
public class FindElderly : MonoBehaviour {

    public float radius;
    private NurseInput input;
    public Elderly current;
    public Elderly last;

    [SerializeField] private LayerMask elderlyMask;

    private void Awake()
    {
        input = GetComponent<NurseInput>();
    }

    private void Update() {
        if (input.SelectElder)
        {
            if (current != null)
            {
                last = current;
                current.SetTarget(null);
                current = null;
            }

            Elderly closestElder = GetClosestElder(Physics.OverlapSphere(transform.position, radius, elderlyMask));
            if (!ReferenceEquals(closestElder, null) && !ReferenceEquals(closestElder, last))
            {
                closestElder.SetTarget(transform);
                current = closestElder;
            }

            last = null;
        }
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
        if(bestDist < float.MaxValue)
            return closest.GetComponent<Elderly>();
        
        return null;
    }
}
