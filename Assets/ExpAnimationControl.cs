using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpAnimationControl : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.GetisDisable())
        {
            animator.speed = 0; // 暂停动画
        }
        else
        {
            animator.speed = 1; // 恢复动画
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(PlayerController.GetisDisable() == false)
            {
                PlayerController.Instance.Restrat();
            }         
        }
    }
}
