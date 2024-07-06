using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoSingleton<CameraFollow>
{
    public Transform target; // ��Ҫ�����Ŀ�����
    public float smoothSpeed = 0.125f; // ����ƽ����
    public Vector3 offset; // �����Ŀ���ƫ����

    void FixedUpdate()
    {
        // ����Ŀ�������λ��
        Vector3 desiredPosition = target.position + offset;
        // ʹ��ƽ����ֵ�ƶ����
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        // ʹ���ʼ������Ŀ��
        transform.LookAt(target);
    }
}
