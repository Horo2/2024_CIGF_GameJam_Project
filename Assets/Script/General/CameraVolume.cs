using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraVolume : MonoSingleton<CameraVolume>
{
    private PostProcessVolume postProcessVolume;
    private ColorGrading colorGrading;

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
    private void Update()
    {
        if (colorGrading != null)
        {
            if (PlayerController.GetisDisable())
            {
                colorGrading.saturation.value = -100f;
            }
            else
            {
                colorGrading.saturation.value = 0;
            }
        }
    }

}
