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
    public int isImpaired;
    public int impairment=1;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isImpaired = moveTime;
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
                {
                    this.transform.Translate(Vector3.up * speed * Time.deltaTime);
                    subtraction();
                }   
                else
                {
                    this.transform.Translate(Vector3.down * speed * Time.deltaTime);
                    subtraction();
                }        
            }
            else
            {
                if (horizontalDirection == 1)
                {
                    this.transform.Translate(Vector3.left * speed * Time.deltaTime);
                    subtraction();
                }
                else
                {
                    this.transform.Translate(Vector3.right * speed * Time.deltaTime);
                    subtraction();
                }
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
            this.impairment = 0;
        }
    }

    private void subtraction()
    {
        isImpaired = (int)(moveTime - impairment * Time.deltaTime);
        if (isImpaired == 0)
        {
            verticalDirection = -1;
            isImpaired = moveTime;
        }
    }
}
