using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    Camera mainCamera;


    // Initialize the camera as main camera
    private void Start() {
        mainCamera = Camera.main;
    }


    // Always face the camera's position and rotation
    private void Update() {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
            mainCamera.transform.rotation * Vector3.up);
    }
}