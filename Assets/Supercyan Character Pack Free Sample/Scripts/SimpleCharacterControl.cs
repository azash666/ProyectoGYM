﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleCharacterControl : MonoBehaviour {

    [SerializeField] private float m_moveSpeed = 4;
    [SerializeField] private float m_jumpForce = 4;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 0.66f;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;

    private bool m_isGrounded;
    private List<Collider> m_collisions = new List<Collider>();

    //Aumentar la velocidad
    public bool isSpeed = false;
    float speedTimer = 0.0f;
    public RawImage imagenVelocidad;


    void Start()
    {
        imagenVelocidad.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for(int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider)) {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if(validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        } else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

	void Update () {

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }

        if (isSpeed)
        {
            speedTimer += Time.deltaTime;
            m_moveSpeed = 7;
            imagenVelocidad.enabled = true;

            if (speedTimer >= 5.0f && speedTimer <= 6.0f)
            {
                isSpeed = false;
                speedTimer = 0.0f;
                m_moveSpeed = 4;
                imagenVelocidad.enabled = false;
            }
        }



        m_animator.SetBool("Grounded", m_isGrounded);

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        bool walk = Input.GetKey(KeyCode.LeftShift);

        if (v < 0)
        {
            if (walk) { v *= m_backwardsWalkScale; }
            else { v *= m_backwardRunScale; }
        }
        else if (walk)
        {
            v *= m_walkScale;
        }

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        if (v == 0)
        {
            transform.position += transform.right * m_currentH * m_moveSpeed * Time.deltaTime;
            m_animator.SetFloat("MoveSpeed", Mathf.Abs(m_currentH));
        }
        else if (h == 0)
        {
            transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;
            m_animator.SetFloat("MoveSpeed", m_currentV);
        }
        else
        {
            m_currentV *= 0.93f;
            m_currentH *= 0.93f;
            transform.position += (transform.forward * m_currentV + transform.right * m_currentH) * m_moveSpeed * Time.deltaTime;
            if (v > 0)
            {
                m_animator.SetFloat("MoveSpeed", Mathf.Abs(m_currentV) + Mathf.Abs(m_currentH));
            }
            else
            {
                m_animator.SetFloat("MoveSpeed", (Mathf.Abs(m_currentV) + Mathf.Abs(m_currentH)) * -1);
            }
        }
        transform.Rotate(0, 3 * Input.GetAxis("Mouse X"), 0);

        m_wasGrounded = m_isGrounded;
    }
}
