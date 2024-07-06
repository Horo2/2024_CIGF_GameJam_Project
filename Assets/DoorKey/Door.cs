using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public BoxCollider2D triggerCollider;  // 用于检测钥匙的触发器
    public Collider2D playerCollider;   // 用于阻挡玩家的碰撞体

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("门检测" + collision.gameObject.name);
        if (collision.gameObject.name == "Key")
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        // 禁用阻挡玩家的碰撞体
        playerCollider.enabled = false;
        // 实现开门逻辑，比如播放动画或切换场景
        Debug.Log("Door is opened.");
        Destroy(this.gameObject);
    }
}
