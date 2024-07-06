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
        isOpen = true;
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
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen)
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
    //如果玩家在水里停止时间，则直接死亡。

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOpen)
            PlayerController.Instance.Restrat();
    }
}
