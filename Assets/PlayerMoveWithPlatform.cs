using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveWithPlatform : MonoBehaviour
{
    private Transform originalParent;
    private PhysicsCheck physicsCheck;
    void Start()
    {
        originalParent = transform.parent;
        physicsCheck = PhysicsCheck.Instance;
    }

    void Update()
    {
        if (physicsCheck.isGround)
        {
            Collider2D groundCollider = Physics2D.OverlapCircle((Vector2)transform.position + physicsCheck.bottomOffset, physicsCheck.Radius, physicsCheck.groundLayer);
            if (groundCollider != null && groundCollider.CompareTag("MovingPlatform"))
            {
                transform.SetParent(groundCollider.transform); // 将玩家的父对象设置为移动平台
            }
            else
            {
                transform.SetParent(originalParent); // 恢复玩家的原始父对象
            }
        }
        else
        {
            transform.SetParent(originalParent); // 恢复玩家的原始父对象
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(collision.transform); // 将玩家的父对象设置为移动平台
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(originalParent); // 恢复玩家的原始父对象
        }
    }
}
