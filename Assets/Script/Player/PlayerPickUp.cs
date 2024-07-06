using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public Transform holdPosition;

    private GameObject pickedUpObject;

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
        pickedUpObject = obj;
        pickedUpObject.GetComponent<Rigidbody2D>().isKinematic = true; // 设置为静态物理对象
        pickedUpObject.transform.SetParent(holdPosition);
        pickedUpObject.transform.localPosition = Vector3.zero; // 重置相对位置
    }

    void DropObject()
    {
        pickedUpObject.transform.SetParent(null);
        pickedUpObject.GetComponent<Rigidbody2D>().isKinematic = false; // 恢复物理效果
        pickedUpObject = null;
    }

}