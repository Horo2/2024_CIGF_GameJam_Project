using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    //向量差
    public Vector2 bottomOffset;
    public bool isGround;
    [Header("检测半径")]
    public float Radius;

    public LayerMask groundLayer;
    void Update()
    {
        Check();
    }

    //物理检测方法
    void Check(){
        //检测是否在地上，通过检测半径是否扫描到Ground图层
       isGround= Physics2D.OverlapCircle((Vector2)transform.position+bottomOffset,Radius,groundLayer);
    }
    //绘制检测范围方法
    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere((Vector2)transform.position+bottomOffset,Radius);
    }
}
