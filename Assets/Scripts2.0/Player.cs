﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public event System.Action OnReachedEndOfLevel;
    public event System.Action DIEDIEDIE;

    CharacterController controller;
    public float acceleration;
    public float friction;
    public float maxSpeed;
    public float RotateSpeed;

    public float diareeeee = 100;

    float speed;
    bool disabled;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(speed != 0 && Mathf.Sign(speed) != Mathf.Sign(friction))
            friction *= -1;

        int mult = (diareeeee > 0) ? 1 : 0;

        float deltaSpeed = (acceleration * Input.GetAxisRaw("Jump") - friction) * Time.deltaTime * mult;
        speed += deltaSpeed;
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        diareeeee -= (Input.GetAxisRaw("Jump") != 0) ? 10 * Time.deltaTime : 0;

        transform.Rotate(transform.up, Input.GetAxisRaw("Horizontal") * RotateSpeed * Time.deltaTime);

        Vector3 velocity = transform.forward * speed * Time.deltaTime;

        controller.Move(velocity);

        if(diareeeee <= 0 && Mathf.Abs(speed) < 3.0f)
        {
            DIEDIEDIE();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        speed *= -0.5f;

        if (hit.gameObject.GetComponent<Nurse>())
        {
            hit.gameObject.GetComponent<Nurse>().Die();
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