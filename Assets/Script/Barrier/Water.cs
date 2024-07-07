using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public BoxCollider2D waterCollider;
    public CapsuleCollider2D waterDieCollider;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        waterCollider = this.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.GetisDisable())
        {
            waterCollider.enabled = true;
            animator.speed = 0; // �ָ�����
        }
        else
        {
            waterCollider.enabled = false;
            animator.speed = 1; // ��ͣ����
        }
    }
    //��ʱ��ֹͣʱ������ײ���������޷���������ʱ������ʱ��û����ײ�������ҿ��Դ�����
    //��������ˮ��ֹͣʱ�䣬��ֱ��������

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (PlayerController.GetisDisable() )
    //        PlayerController.Instance.Restrat();
    //}
}
