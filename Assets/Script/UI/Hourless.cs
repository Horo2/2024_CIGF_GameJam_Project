using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourless : MonoBehaviour
{
    // 动画机
    public Animator anim;
    public bool isDisabled;

    // Start is called before the first frame update
    void Start()
    {
        isDisabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAnimation();
    }

    public void ChangeAnimation()
    {
        isDisabled = PlayerController.GetisDisable();
        
        anim.SetBool("isDisabled", isDisabled);
    }
}
