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

    // ��ʱ��ֹͣʱ������/���������治���ƶ�����ʱ������ʱ���������������һ�������ƶ���
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
