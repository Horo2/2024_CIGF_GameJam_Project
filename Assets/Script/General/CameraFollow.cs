using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoSingleton<CameraFollow>
{
    public Transform target; // 需要跟随的目标对象
    public float smoothSpeed = 0.125f; // 跟随平滑度
    public Vector3 offset; // 相机与目标的偏移量

    void FixedUpdate()
    {
        // 计算目标的理想位置
        Vector3 desiredPosition = target.position + offset;
        // 使用平滑插值移动相机
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        // 使相机始终面向目标
        transform.LookAt(target);
    }
}
