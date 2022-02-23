using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMove : MonoBehaviour
{
   
    public float turnSpeed = 25.0f;

    Vector3 mMove;
    Animator aAnimator;
    Rigidbody rRigidbody;
    AudioSource audioSource;   
    Quaternion rRotation = Quaternion.identity;

    void Start()
    {
        aAnimator = GetComponent<Animator>();
        rRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 

        mMove.Set(horizontal, 0f, vertical);
        mMove.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f); 
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        aAnimator.SetBool("IsWalking", isWalking);
        Vector3 moveForward = Vector3.RotateTowards(transform.forward, mMove, turnSpeed * Time.deltaTime, 0f);
        rRotation = Quaternion.LookRotation(moveForward);

        if (isWalking)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

    }
    void OnAnimatorMove()
    {
        rRigidbody.MovePosition(rRigidbody.position + mMove * aAnimator.deltaPosition.magnitude);
        rRigidbody.MoveRotation(rRotation);
    }
}
