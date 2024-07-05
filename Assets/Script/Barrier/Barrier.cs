using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    //障碍物表现速度
    public int speed;
    //障碍物实际速度
    public int actualSpeed;
    //障碍物重力
    public int gravity;
    //障碍物移动方向
    public int horizontalDirection;//左右
    public int verticalDirection;//上下
    //移动时间
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
            this.m
        }else
        {
            speed = 0;
        }
    }
}
