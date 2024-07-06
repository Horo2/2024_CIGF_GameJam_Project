using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DilapidatedPlatform : MonoBehaviour
{
    public bool isOpen;
    public BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = true;
        bc= this.GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        PlayerController.Instance.OnStateSwitching += OnStateSwitching;
        PlayerController.Instance.OnUpdateScene += OnUpdateScene;
    }

    private void OnDisable()
    {
        PlayerController.Instance.OnStateSwitching -= OnStateSwitching;
        PlayerController.Instance.OnUpdateScene -= OnUpdateScene;
    }
    private void OnUpdateScene()
    {
        isOpen = false;
        this.gameObject.SetActive(true);
    }

    private void OnStateSwitching()
    {
        isOpen = !isOpen;
    }

    //当时间停止时，有碰撞体积，玩家可以站立在上面。当时间流动时，玩家站立在上面，平台会被破坏，也可以被其他物体触发。
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isOpen)
        {
            this.gameObject.SetActive(false);
        }
    }
}
