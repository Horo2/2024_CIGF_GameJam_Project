using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledManager : MonoBehaviour
{
    public bool isDisabled;
    // Start is called before the first frame update
    void Start()
    {
        isDisabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        isDisabled = PlayerController.GetisDisable();
        OnInteractSwitching();
    }

    /*
    private void OnEnable()
    {
        PlayerController.Instance.OnStateSwitching += OnState;
        PlayerController.Instance.OnStateSwitching += OnInteractSwitching;
    }

    private void OnDisable()
    {
        PlayerController.Instance.OnStateSwitching -= OnState;
        PlayerController.Instance.OnStateSwitching -= OnInteractSwitching;
    }
    */
    private void OnInteractSwitching()
    {
        GameObject[] interactObjects = GameObject.FindGameObjectsWithTag("InteractObject");
        if (interactObjects != null && interactObjects.Length > 0)
        {
            foreach (GameObject obj in interactObjects)
            {
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    if (isDisabled)
                    {
                        rb.bodyType = RigidbodyType2D.Static; // 设置为静态物理对象
                    }
                    else
                    {
                        rb.bodyType = RigidbodyType2D.Dynamic; // 恢复为动态物理对象
                    }
                }
                /*
                Collider2D collider = obj.GetComponent<Collider2D>();
                if (collider != null)
                {
                    collider.enabled = !isDisabled; // 切换碰撞体状态
                }*/
            }
        }
    }



}
