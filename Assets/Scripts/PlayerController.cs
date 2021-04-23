using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    private float speed = 8f;
    private float upSpeed = 25f;

    private bool puedoSaltar = false;
    private bool muerte = false;
    
    private int punto = 0;

    private Animator animator;
    private Rigidbody2D rb2d;
   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!muerte)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            setRunAnimation();
        }

        if (punto == 10)
        {
            speed = speed * 2;
            punto = 0;
            Debug.Log("Velocidad: " + speed);
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && !muerte)
        {
            setJumpAnimation();
            rb2d.velocity = Vector2.up * upSpeed;

        }

        if (muerte)
        {
            setdeadAnimation();
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 9)
            muerte = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 10)
        {
            punto++;
            
        }

    }

    private void setRunAnimation()
    {
        animator.SetInteger("Estate", 1);
    }
    
    private void setJumpAnimation()
    {
        animator.SetInteger("Estate", 2);
    }
    
    private void setIdleAnimation()
    {
        animator.SetInteger("Estate", 0);
    }

    private void setdeadAnimation()
    {
        animator.SetInteger("Estate", 3);
    }

}
