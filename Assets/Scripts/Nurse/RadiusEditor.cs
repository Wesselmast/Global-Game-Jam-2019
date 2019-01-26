using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FindElderly))]
public class FOVEditor : Editor {

    private void OnSceneGUI() {
        FindElderly fov = (FindElderly)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);
    }
}
