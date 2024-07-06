using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGenetor : MonoBehaviour
{

    public GameObject BoxPrefab; // 炮弹预制体
    public GameObject muzzleFlashPrefab; // 发射特效预制体
    public Transform firePoint; // 发射点
    public float fireRate = 2f; // 发射间隔时间

    private bool isFiring = false; // 记录当前是否在发射
    private Coroutine GenetorCoroutine;
    void Update()
    {
        if (PlayerController.GetisDisable() == false)
        {
            Debug.Log("不可发射");
            if (!isFiring)
            {
                // 恢复发射
                GenetorCoroutine = StartCoroutine(GenetorBox());
                isFiring = true;
                // 暂停发射
                
            }
        }
        else
        {
            Debug.Log("可发射");
            if (isFiring)
            {
                StopCoroutine(GenetorCoroutine);
                isFiring = false;

            }

        }
    }

    private IEnumerator GenetorBox()
    {
        while (true)
        {
            // 等待设定的发射间隔时间
            yield return new WaitForSeconds(fireRate);

            // 生成发射特效
            if (muzzleFlashPrefab != null)
            {
                Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation);
            }
            else
            {
                Debug.LogWarning("Does not have Muzzle Flash Prefab on Launcher");
            }

            // 生成炮弹
            Instantiate(BoxPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
