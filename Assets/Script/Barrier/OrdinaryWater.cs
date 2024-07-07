using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdinaryWater : MonoBehaviour
{
    public BoxCollider2D waterCollider;
    public BoxCollider2D waterTrigger;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        waterCollider = this.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.GetisDisable())
        {
            waterCollider.enabled = true;
            animator.speed = 0; // 恢复动画
        }
        else
        {
            waterCollider.enabled = false;
            animator.speed = 1; // 暂停动画
        }
    }
    //当时间停止时，有碰撞体积，玩家无法穿过。当时间流动时，没有碰撞体积，玩家可以穿过。
    //如果玩家在水里停止时间，则直接死亡。

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PlayerController.GetisDisable() && collision.gameObject.CompareTag("Player") == true)
            PlayerController.Instance.Restrat();
    }
}
