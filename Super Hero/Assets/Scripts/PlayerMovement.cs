using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float jumpHeight;
    public float speed;

    public bool IsGrounded;
    public LayerMask WhatIsGround;
    public float groundRadius;

    public float raylength;

    public GameObject dialougecontrol;
    public GameObject canvas;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.queriesStartInColliders = false;
    }

    void FixedUpdate()
    {
        Move();
        Ray();
    }

    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(transform.position, groundRadius, WhatIsGround);

        if (IsGrounded)
        {
            Physics2D.IgnoreLayerCollision(8, 10);
        }
        if(Input.GetButtonDown("Jump")&&IsGrounded==true)
        {
            Jump();
        }
    }

    void Move()
    {
        float xHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xHorizontal * speed , rb.velocity.y);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpHeight);
    }

    void Ray()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.left, raylength);
        if (hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.name == "Ned Stark")
            {

              //  Destroy(hit2D.collider.gameObject, 5f);
                dialougecontrol.SetActive(true);
                canvas.SetActive(true);
                speed = 0f;
                jumpHeight = 0f;
                Debug.Log(hit2D.collider.gameObject.name);
                Debug.DrawRay(transform.position, Vector2.left * raylength, Color.green);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.left * 10f, Color.red);
        }
    }

}
