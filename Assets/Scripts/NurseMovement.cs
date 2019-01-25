using UnityEngine;

[RequireComponent(typeof(NurseInput))]
[RequireComponent(typeof(CharacterController))]
public class NurseMovement : MonoBehaviour {
    [SerializeField]
    private float speed;

    private NurseInput input;
    private CharacterController controller;

    private void Awake () {
        input = GetComponent<NurseInput>();
        controller = GetComponent<CharacterController>();
	}
	
	private void FixedUpdate () {
        Vector3 velocity = new Vector3(input.Horizontal, 0, input.Vertical) * Time.deltaTime * speed;
        controller.Move(velocity);
    }
}
