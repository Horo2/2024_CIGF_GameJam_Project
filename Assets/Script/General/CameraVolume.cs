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
        // ��ȡ������ϵ� Post-Processing Volume ���
        postProcessVolume = GetComponent<PostProcessVolume>();

        // ȷ�� Post-Processing Volume �������
        if (postProcessVolume != null)
        {
            // ��ȡ Color Grading ����
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
                // ���úڰ��˾�Ч��
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
