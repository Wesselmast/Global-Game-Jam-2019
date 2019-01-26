using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    [SerializeField] private float scrollSpeed;
    [SerializeField] private float smooth;
    [SerializeField] private GameObject nurse;
    private Vector3 zeroRef = Vector3.zero;
    private NurseInput input;
    private Vector3 startPos;
    private Vector3 scrollDist;
    private float travel;

    private void Awake () {
        input = nurse.GetComponent<NurseInput>();
	}

    private void Start() {
        startPos = transform.position;
    }

    private void FixedUpdate () {
        SmoothFollow();
        Scrolling();
    }

    private void SmoothFollow() {
        Vector3 targetPosition = nurse.transform.position + startPos + scrollDist;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref zeroRef, smooth);
    }

    private void Scrolling() {
        if (input.ScrollPos > 0f && travel > -6.5f) travel = travel - scrollSpeed;
        else if (input.ScrollPos < 0f && travel < 1)  travel = travel + scrollSpeed;
        scrollDist = new Vector3(0, travel, 0);
    }
}