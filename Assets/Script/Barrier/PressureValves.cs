using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressureValves : MonoBehaviour
{
    public HighPressureWater highWater;
    public bool flag;
    public bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = true;
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
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(isOpen)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (flag)
                {
                    highWater.SetWaterUp();
                }
                else
                    highWater.SetWaterDown();
            }
        }
    }

    private void OnUpdateScene()
    {
        isOpen = false;
    }

    private void OnStateSwitching()
    {
        isOpen = !isOpen;
    }
}
