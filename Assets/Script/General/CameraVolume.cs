using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraVolume : MonoSingleton<CameraVolume>
{
    private PostProcessVolume postProcessVolume;
    private ColorGrading colorGrading;
    public bool isOpen=false;

    private void Start()
    {
        // 获取摄像机上的 Post-Processing Volume 组件
        postProcessVolume = GetComponent<PostProcessVolume>();

        // 确保 Post-Processing Volume 组件存在
        if (postProcessVolume != null)
        {
            // 获取 Color Grading 设置
            postProcessVolume.profile.TryGetSettings(out colorGrading);
        }
        
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

    

    private void Update()
    {
        if (colorGrading != null)
        {
            if (isOpen)
            {
                // 设置黑白滤镜效果
                colorGrading.saturation.value = -100f;
            }
            else
            {
                colorGrading.saturation.value = 0;
            }
        }



    }

    private void OnStateSwitching()
    {
        isOpen = !isOpen;
    }

    private void OnUpdateScene()
    {
        isOpen = true;
    }

}
