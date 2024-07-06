using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressureValves : MonoBehaviour
{
    public HighPressureWater highWater;
    public bool flag { get; set; }
    public bool isOpen;
    public bool dic;
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
        if (isOpen)
        {
            if (flag)
            {
                if(dic)
                {
                    highWater.SetWaterUp();
                    dic = !dic;
                }
                else
                {
                    highWater.SetWaterDown();
                    dic = !dic;
                }
                    
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
