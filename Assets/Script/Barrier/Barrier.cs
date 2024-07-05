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
    //障碍物移动方向
    public int horizontalDirection;//左右
    public int verticalDirection;//上下
    //移动时间
    public int moveTime;
    public float isImpaired;
    private int impairment = 1;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = actualSpeed;
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
        if (rb != null)
        {
            if (this.horizontalDirection == 0)
            {
                if (verticalDirection == 1)
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
        if (speed == 0)
        {
            speed = actualSpeed;
            this.impairment = 1;
        }
        else
        {
            speed = 0;
            this.impairment = 0;
        }
    }

    private void subtraction()
    {
        isImpaired = isImpaired - impairment*Time.deltaTime;
        if (isImpaired <= 0)
        {
            if (horizontalDirection == 0)
                verticalDirection = -verticalDirection; 
            else
                horizontalDirection = -horizontalDirection;
            isImpaired = moveTime;
        }
    }
}
