using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCamera : MonoBehaviour {

    [SerializeField] private float scrollSpeed;
    [SerializeField] private float smooth;
    [SerializeField] private GameObject nurse;
    private Vector3 zeroRef = Vector3.zero;
    private NurseInput input;
    private Camera cam;
    private Vector3 startPos;
    private float travel;

    private void Awake () {
        input = nurse.GetComponent<NurseInput>();
        cam = GetComponent<Camera>();
	}

    private void Start() {
        startPos = transform.position;
    }

    private void FixedUpdate () {
        SmoothFollow();
        Scrolling();
    }

    private void SmoothFollow() {
        Vector3 targetPosition = nurse.transform.position + startPos;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref zeroRef, smooth);
    }

    private void Scrolling() {
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