using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour
{
    Animator m_Animator;
    Vector3 m_Moviement;
    public float turnSpeed = 20f;
    Quaternion m_Rotation = Quaternion.identity;
    Rigidbody m_Rigidbody;
    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        audiosource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yoko = Input.GetAxis("Horizontal");
        float tate = Input.GetAxis("Vertical");
                      
        m_Moviement.Set(yoko, 0f, tate);
        m_Moviement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(yoko, 0f);
        bool hasVerticalInput = !Mathf.Approximately(tate, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
        }
        else
        {
            audiosource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Moviement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }


    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Moviement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
