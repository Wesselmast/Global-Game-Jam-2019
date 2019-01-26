using UnityEngine;

public class Exit : MonoBehaviour {

    [SerializeField] private float homefullnessLoseAmt;

    private void OnTriggerEnter(Collider other) {
        foreach (var e in FindObjectsOfType<Interest>()) e.Homefulness -= homefullnessLoseAmt;
        Destroy(other);
    }
}