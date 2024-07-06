using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shells : MonoBehaviour
{

    public float sheelsSpeed = 10f;
    public GameObject explosionEffect;
    private Rigidbody2D _rb;
    private PlayerController player;
    public float detectionDistance = 0.1f;
    public Vector2 offset = new Vector2(0.5f, 0); // 射线的起点相对于炮弹中心的偏移量
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player").GetComponent<PlayerController>();
 
    }

    private void Update()
    {
        if(PlayerController.GetisDisable())
        {
            this.transform.Translate(Vector3.right * 0 * Time.deltaTime);
        }
        else
        {
            this.transform.Translate(Vector3.right * sheelsSpeed * Time.deltaTime);
        }

        Vector2 rayOrigin = (Vector2)transform.position + offset;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, detectionDistance);

        if (hit.collider != null && !hit.collider.CompareTag("Player") && hit.collider.gameObject != this.gameObject)
        {
            // 在碰撞位置生成爆炸特效
            Instantiate(explosionEffect, hit.point, transform.rotation);

            // 销毁炮弹
            Destroy(gameObject);
        }
    }

    // 可视化检测范围
    // 可视化检测范围和射线起点
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // 绘制射线起点
        Vector2 rayOrigin = (Vector2)transform.position + (Vector2)transform.right * offset.x;
        Gizmos.DrawSphere(rayOrigin, 0.05f); // 绘制一个小圆圈表示射线起点

        // 绘制射线
        Gizmos.DrawLine(rayOrigin, rayOrigin + (Vector2)transform.right * detectionDistance);
    }
}
