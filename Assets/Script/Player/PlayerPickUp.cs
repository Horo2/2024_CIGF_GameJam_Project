using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public Transform holdPosition;

    public GameObject pickedUpObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (pickedUpObject == null)
            {
                Debug.Log("尝试捡起");
                TryPickUpObject();
            }
            else
            {
                Debug.Log("放下");
                DropObject();
            }
        }
    }

    void TryPickUpObject()
    {
        Debug.Log("捡起中...");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.0f); // 定义一个圆形范围来检测附近的物体
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("InteractObject"))
            {
                Debug.Log("拾起");
                PickUpObject(collider.gameObject);
                break;
            }
        }
    }

    void PickUpObject(GameObject obj)
    {
        Debug.Log("捡起物体：" + obj.name);
        pickedUpObject = obj;
        Rigidbody2D rb = pickedUpObject.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        // 重置位置和旋转
        pickedUpObject.transform.position = holdPosition.position;
        pickedUpObject.transform.rotation = holdPosition.rotation;

        // 设置父级为 holdPosition
        pickedUpObject.transform.SetParent(holdPosition);
    }

    void DropObject()
    {
        pickedUpObject.transform.SetParent(null);
        // 恢复物理属性
        Rigidbody2D rb = pickedUpObject.GetComponent<Rigidbody2D>();
        rb.isKinematic = false;

        pickedUpObject = null;
    }

}