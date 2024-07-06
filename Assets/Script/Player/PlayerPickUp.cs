using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public Transform holdPosition;

    public GameObject pickedUpObject;

    private static List<GameObject> pickedUpObjects = new List<GameObject>();

    public float throwForce = 8f; // 调整这个值来控制投掷力度
    public float upwardForce = 2f; // 调整这个值来控制向上的力

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

        // 检测鼠标左键点击并且当前有捡起的物体
        if (Input.GetMouseButtonDown(0) && pickedUpObject != null)
        {
            Throw();
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

        // 将拾起的物体添加到列表中
        pickedUpObjects.Add(pickedUpObject);
    }

    void DropObject()
    {
        pickedUpObject.transform.SetParent(null);
        // 恢复物理属性
        Rigidbody2D rb = pickedUpObject.GetComponent<Rigidbody2D>();
        rb.isKinematic = false;

        pickedUpObject = null;
    }

    // 抛物线扔出去
    void Throw()
    {
        if (pickedUpObject != null)
        {
            pickedUpObject.transform.SetParent(null);

            Rigidbody2D rb = pickedUpObject.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;

            // 获取玩家移动方向
            Vector2 playerDirection = PlayerController.Instance.inputDirection;

            // 计算投掷方向和力度，添加一个向上的力
            Vector2 throwDirection = playerDirection.normalized + Vector2.up * upwardForce;
            rb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);

            pickedUpObject = null;
        }
    }

    // 场景刷新时调用此方法
    public static void OnSceneRefresh()
    {
        foreach (var obj in pickedUpObjects)
        {
            Destroy(obj);
        }
        pickedUpObjects.Clear();
    }
}
