using UnityEngine;

public class Player : MonoBehaviour {

    public event System.Action OnReachedEndOfLevel;
    public event System.Action DIEDIEDIE;

    CharacterController controller;
    public float acceleration;
    public float friction;
    public float maxSpeed;
    public float RotateSpeed;

    public float maxDiaree = 150f;
    public float diareeeee = 150f;

    public float speed;
    bool disabled;

    public Transform wheel1;
    public Transform wheel2;

    public ParticleSystem syst1;
    public ParticleSystem syst2;
    public ParticleSystem syst3;
    AudioSource src;
    public AudioSource src2;
    public AudioClip clip;

    bool canSOund;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        src = GetComponent<AudioSource>();
        src.volume = 0.5f;
    }

    private void Update()
    {
        if(speed != 0 && Mathf.Sign(speed) != Mathf.Sign(friction))
            friction *= -1;

        int mult = (diareeeee > 0) ? 1 : 0;

        float deltaSpeed = (acceleration * Input.GetAxisRaw("Jump") * mult - friction) * Time.deltaTime ;
        speed += deltaSpeed;
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        diareeeee -= (Input.GetAxisRaw("Jump") != 0) ? 10 * Time.deltaTime : 0;
        diareeeee = Mathf.Clamp(diareeeee, 0, maxDiaree);

        if((Input.GetAxisRaw("Jump") != 0 && diareeeee > 0))
        {
            src.volume = 0.7f;
            syst1.emissionRate = 100;
            syst2.emissionRate = 100;
            syst3.emissionRate = 100;
        }
        else
        {
            src.volume = 0;
            syst1.emissionRate = 0;
            syst2.emissionRate = 0;
            syst3.emissionRate = 0;
        }

        transform.Rotate(transform.up, Input.GetAxisRaw("Horizontal") * RotateSpeed * Time.deltaTime);

        Vector3 velocity = transform.forward * speed * Time.deltaTime;

        controller.Move(velocity);

        if(diareeeee <= 0 && Mathf.Abs(speed) < 1.0f)
        {
            DIEDIEDIE();
        }

        if(speed > 10)
        {
            canSOund = true;
        }

        wheel1.RotateAroundLocal(Vector3.forward, -Time.deltaTime * speed * 2);
        wheel2.RotateAroundLocal(Vector3.forward, -Time.deltaTime * speed * 2);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        speed *= -0.5f;

        if (hit.gameObject.GetComponent<Nurse>())
        {
            hit.gameObject.GetComponent<Nurse>().Die();
        }
        else

        {
            if (canSOund)
            {
                src2.pitch = Random.Range(0.9f, 1.1f);
                src2.PlayOneShot(clip);
                canSOund = false;
            }
        }
    }

    void OnTriggerEnter(Collider hitCollider)
    {
        if (hitCollider.tag == "End")
        {
            Disable();
            if (OnReachedEndOfLevel != null)
            {
                OnReachedEndOfLevel();
            }
        }

        if (hitCollider.tag == "Food")
        {
            Destroy(hitCollider.gameObject);
            diareeeee += 30f;
        }



    }

    void Disable()
    {
        disabled = true;
    }
}
