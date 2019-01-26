using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {
    private Transform target;

    private void Awake() {
        target = FindObjectOfType<Camera>().transform;
    }

    private void FixedUpdate() {
        transform.LookAt(target);
    }
}
