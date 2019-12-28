using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float turnSpeed = 20f;

    Animator Animator;
    Rigidbody Rigidbody;

    Vector3 Movement = Vector3.zero;
    Quaternion Rotation = Quaternion.identity;

    void Start() {
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        Animator.SetBool("IsWalking", isWalking);

        Movement = new Vector3(horizontal, 0f, vertical).normalized;

        var desiredForward = Vector3.RotateTowards(transform.forward, Movement, turnSpeed * Time.deltaTime, 0f);
        Rotation = Quaternion.LookRotation(desiredForward);
    }

    void OnAnimatorMove() {
        Rigidbody.MovePosition(Rigidbody.position + Movement * Animator.deltaPosition.magnitude);
        Rigidbody.MoveRotation(Rotation);
    }
}
