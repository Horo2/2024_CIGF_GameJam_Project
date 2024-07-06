using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public bool isOpen;
    public CapsuleCollider2D capsuleCollider;
    public Rigidbody2D rb;
    //���ʹ�����0Ϊ��1Ϊ��
    public int horizontal;
    //���ʹ��ٶ�
    public float moveSpeed;


    public Animator anim;

    // Time between frames
    public float frameRate = 0.1f;
    private float timer;
    private int currentFrame;


    void Start()
    {
        isOpen = true;
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

    // ��ʱ��ֹͣʱ������/���������治���ƶ�����ʱ������ʱ���������������һ�������ƶ���
    void Update()
    {
        bool isDisabled = PlayerController.GetisDisable();
        Debug.Log("isDisabled" + isDisabled);
        if (isDisabled)
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
            if (isOpen)
            {
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.left * horizontal * moveSpeed, ForceMode2D.Force);

            }
        }
    }
}
