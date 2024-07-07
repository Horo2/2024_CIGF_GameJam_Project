using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{
    public BoxCollider2D waterCollider;
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
            animator.speed = 0; // »Ö¸´¶¯»­
        }
        else
        {
            waterCollider.enabled = false;
            animator.speed = 1; // ÔÝÍ£¶¯»­
        }
    }
}
