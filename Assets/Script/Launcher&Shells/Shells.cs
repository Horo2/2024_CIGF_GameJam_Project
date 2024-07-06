using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shells : MonoBehaviour
{

    public float sheelsSpeed = 10f;
    public GameObject explosionEffect;
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.right * sheelsSpeed; // 朝右边飞行
    }

    private void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 在碰撞位置生成爆炸特效
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // 销毁炮弹
        Destroy(gameObject);
    }
}
