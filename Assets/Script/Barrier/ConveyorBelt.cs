using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public bool isOpen;
    public CapsuleCollider2D capsuleCollider;
    public Rigidbody2D rb;
    //传送带方向，0为左，1为右
    public int horizontal;
    //传送带速度
    public float moveSpeed;
    void Start()
    {
        isOpen = false;
        capsuleCollider = this.GetComponent<CapsuleCollider2D>();
    }

    private void OnEnable()
    {
        PlayerController.Instance.OnStateSwitching += OnStateSwitching;
        PlayerController.Instance.OnUpdateScene += OnUpdateScene;
    }

    private void OnDisable()
    {
        PlayerController.Instance.OnStateSwitching -= OnStateSwitching;
        PlayerController.Instance.OnUpdateScene -= OnUpdateScene;
    }

    private void OnUpdateScene()
    {
        isOpen = false;
    }

    private void OnStateSwitching()
    {
        isOpen = !isOpen;
    }

    // 当时间停止时候，人物/物体在上面不会移动。当时间流动时，物体在上面会往一个方向移动。
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        rb = collision.GetComponent<Rigidbody2D>();
        if(rb!= null)
        {
            if (!isOpen)
            {
                rb.AddForce(Vector2.left * horizontal * moveSpeed, ForceMode2D.Force);

            }
        }
    }
}
