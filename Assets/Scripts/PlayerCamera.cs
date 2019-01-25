using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCamera : MonoBehaviour {

    [SerializeField] private float scrollSpeed;
    [SerializeField] private float maxDist;

    private GameObject nurse;
    private NurseInput input;
    private Camera cam;
    private float travel;

    private void Awake () {
        nurse = transform.parent.gameObject;
        input = nurse.GetComponent<NurseInput>();
        cam = GetComponent<Camera>();
	}
	
	private void FixedUpdate () {

        float scrollPos = input.ScrollPos;
        if (scrollPos > 0f && travel > 30) {
            travel = travel - scrollSpeed;
            //transform.Translate(0, 0, 1 * scrollSpeed, Space.Self);
        }
        else if (scrollPos < 0f && travel < 75) {
            travel = travel + scrollSpeed;
            //transform.Translate(0, 0, -1 * scrollSpeed, Space.Self);
        }
        cam.fieldOfView = travel;
    }
}
