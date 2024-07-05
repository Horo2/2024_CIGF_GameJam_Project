using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    //�ϰ�������ٶ�
    public int speed;
    //�ϰ���ʵ���ٶ�
    public int actualSpeed;
    //�ϰ�������
    public int gravity;
    //�ϰ����ƶ�����
    public int horizontalDirection;//����
    public int verticalDirection;//����
    //�ƶ�ʱ��
    public int moveTime;
    public int impairment=1;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        PlayerController.Instance.OnStateSwitching += OnStateSwitching;
    }

    private void OnDisable()
    {
        PlayerController.Instance.OnStateSwitching -= OnStateSwitching;
    }

    private void Update()
    {
        if(rb!= null)
        {
            if(this.horizontalDirection == 0)
            {
                if(verticalDirection == 1)
                    this.transform.Translate(Vector3.up * speed * Time.deltaTime);
                else
                    this.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else
            {
                if (horizontalDirection == 1)
                    this.transform.Translate(Vector3.left*speed*Time.deltaTime);
                else
                    this.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
    private void OnStateSwitching()
    {
        if(speed == 0)
        {
            speed = actualSpeed;
        }else
        {
            speed = 0;
        }
    }
}
