using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;

    public Monedas monedasOP;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        setIdleAnimation();
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        if (Input.GetKey(KeyCode.RightArrow)  )      {
            sr.flipX = false; // derecha
            setRunAnimation();
            rb2d.velocity = new Vector2(5, rb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow)  )      {
            sr.flipX = true; // izquierda
            setRunAnimation();
            rb2d.velocity = new Vector2(-5, rb2d.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space)   )     {
            setJumpAnimation();
            rb2d.velocity = Vector2.up * 5;
        }
        if (Input.GetKey(KeyCode.DownArrow) ){
            setslideAnimation();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("plata");
            monedasOP.Puntos(10);
            Destroy(other.gameObject); // destruye el objeto con el que choca
        }
        if (other.gameObject.layer == 7)
        {
            Debug.Log("oro");
            monedasOP.Puntos(20);
            Destroy(other.gameObject);
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

    private void setslideAnimation()
    {
        animator.SetInteger("Estate", 4);
    }
}