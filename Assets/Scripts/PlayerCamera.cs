using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    [SerializeField] private float scrollSpeed;
    [SerializeField] private float smooth;
    [SerializeField] private GameObject nurse;
    private Vector3 zeroRef = Vector3.zero;
    public Player player;
    private Vector3 startPos;
    private Vector3 scrollDist;
    private float travel;
    private float distance;


    private void Start() {
        startPos = transform.position;
        distance = Vector3.Distance(transform.position, nurse.transform.position);
    }

    private void LateUpdate () {
        SmoothFollow();
    }

    private void SmoothFollow() {
        Vector3 targetPosition = nurse.transform.position + transform.forward * -(distance + Mathf.Clamp(player.speed/3,1,10));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref zeroRef, smooth);
    }

    
}