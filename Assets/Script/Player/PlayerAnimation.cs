using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    
    private Animator anim;
    
    private void Awake()
    {
        anim =GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        physicsCheck=GetComponent<PhysicsCheck>();
    }

    private void Update() {
        
        SetAnimation();
    }

    private void SetAnimation()
    {
        anim.SetFloat("velocityX",Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY",rb.velocity.y);  
        anim.SetBool("isGound",physicsCheck.isGround);
    }
}
