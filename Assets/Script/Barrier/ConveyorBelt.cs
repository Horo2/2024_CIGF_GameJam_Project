using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public CapsuleCollider2D capsuleCollider;
    public Rigidbody2D rb;
    public int horizontal;
    public float moveSpeed;
    public Animator anim;

    void Start()
    {
        capsuleCollider = this.GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        if (PlayerController.GetisDisable())
        {
            
            anim.SetBool("isDisabled", true);
        }
        else
        {
            anim.SetBool("isDisabled", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        rb = collision.GetComponent<Rigidbody2D>();
        if(rb!= null)
        {
            if (!PlayerController.GetisDisable())
            {
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.left * horizontal * moveSpeed, ForceMode2D.Force);

            }
        }
    }
}
