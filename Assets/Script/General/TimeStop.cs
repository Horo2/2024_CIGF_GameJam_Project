using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
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
            animator.speed = 0; // »Ö¸´¶¯»­
        }
        else
        {
            animator.speed = 1; // ÔÝÍ£¶¯»­
        }
    }
}
