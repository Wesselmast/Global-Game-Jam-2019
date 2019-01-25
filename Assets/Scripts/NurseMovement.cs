using UnityEngine;

[RequireComponent(typeof(NurseInput))]
[RequireComponent(typeof(CharacterController))]
public class NurseMovement : MonoBehaviour {
    [SerializeField]
    private float speed;

    private NurseInput input;
    private CharacterController controller;
    private float startY;

    private void Awake () {
        input = GetComponent<NurseInput>();
        controller = GetComponent<CharacterController>();
	}

    private void Start() {
        startY = transform.position.y;
    }

	private void FixedUpdate () {
        Vector3 velocity = new Vector3(input.Horizontal, 0f, input.Vertical) * Time.deltaTime * speed;
        transform.position = new Vector3(transform.position.x, startY, transform.position.z);
        controller.Move(velocity);
    }
}
