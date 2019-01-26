using System;
using UnityEngine;

public class NurseInput : MonoBehaviour {

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public float ScrollPos { get; private set; }
    public bool SelectElder { get; private set; }

    private void Update () {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        ScrollPos = Input.GetAxis("Mouse ScrollWheel");
        SelectElder = Input.GetKeyDown(KeyCode.E);
    }
}
