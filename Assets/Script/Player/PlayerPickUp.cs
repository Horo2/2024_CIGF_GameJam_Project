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


        // 确保物体跟随 holdPosition
        if (pickedUpObject != null)
        {
            // 检测物体的 Rigidbody 是否为 Static
            Rigidbody2D rb = pickedUpObject.GetComponent<Rigidbody2D>();
            if (rb != null && rb.bodyType == RigidbodyType2D.Static)
            {
                Debug.Log("检测到静态物体，自动解除绑定");
                DropObject();
            }
            else
            {
                pickedUpObject.transform.position = holdPosition.position;
                pickedUpObject.transform.rotation = holdPosition.rotation;
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

        // 设置父级为 holdPosition
        pickedUpObject.transform.SetParent(holdPosition);
        // 重置位置和旋转
        pickedUpObject.transform.localPosition = Vector3.zero;
        pickedUpObject.transform.localRotation = Quaternion.identity;
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