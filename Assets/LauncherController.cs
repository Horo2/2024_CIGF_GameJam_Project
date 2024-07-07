using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public GameObject shellPrefab; // 炮弹预制体
    public GameObject muzzleFlashPrefab; // 发射特效预制体
    public Transform firePoint; // 发射点
    public Transform muzzleFlashGenetorPoint;
    public float fireRate = 2f; // 发射间隔时间

    private bool isFiring = false; // 记录当前是否在发射
    private Coroutine fireCoroutine;


    void Update()
    {
        if (PlayerController.GetisDisable() == false)
        {
            if (!isFiring)
            {
              // 恢复发射
                fireCoroutine = StartCoroutine(FireShells());
                isFiring = true;
            }
        }
        else
        {
            if (isFiring)
            {

                // 暂停发射
                StopCoroutine(fireCoroutine);
                isFiring = false;
            }
            
        }
    }

    private IEnumerator FireShells()
    {
        while (true)
        {
            // 等待设定的发射间隔时间
            yield return new WaitForSeconds(fireRate);

            // 生成发射特效
            if(muzzleFlashPrefab!= null)
            {
                Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation);
            }
            else
            {
                Debug.LogWarning("Does not have Muzzle Flash Prefab on Launcher");
            }
           
            // 生成炮弹
            Instantiate(shellPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
