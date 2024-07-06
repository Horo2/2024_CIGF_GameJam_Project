using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool isOpen;
    public BoxCollider2D waterCollider;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        waterCollider = this.GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        PlayerController.Instance.OnStateSwitching += OnStateSwitching;
    }

    private void OnDisable()
    {
        PlayerController.Instance.OnStateSwitching -= OnStateSwitching;
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
    //当时间停止时，有碰撞体积，玩家无法穿过。当时间流动时，没有碰撞体积，玩家可以穿过。
    private void OnStateSwitching()
    {
        isOpen = !isOpen;
    }
}
