using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DilapidatedPlatform : MonoBehaviour
{
    public BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        bc= this.GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        PlayerController.Instance.OnUpdateScene += OnUpdateScene;
    }

    private void OnDisable()
    {
        PlayerController.Instance.OnUpdateScene -= OnUpdateScene;
    }
    private void OnUpdateScene()
    {
        this.gameObject.SetActive(true);
    }

    //当时间停止时，有碰撞体积，玩家可以站立在上面。当时间流动时，玩家站立在上面，平台会被破坏，也可以被其他物体触发。
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!PlayerController.GetisDisable())
        {
            this.gameObject.SetActive(false);
        }
    }
}
