using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool isOpen;
    public BoxCollider2D waterCollider;
    public CapsuleCollider2D waterDieCollider;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        waterCollider = this.GetComponent<BoxCollider2D>();
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
        isOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOpen)
        {
            waterCollider.enabled = false;
        }
        else
        {
            waterCollider.enabled = true;
        }
    }
    //��ʱ��ֹͣʱ������ײ���������޷���������ʱ������ʱ��û����ײ�������ҿ��Դ�����
    private void OnStateSwitching()
    {
        isOpen = !isOpen;
    }
}
