using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    //能量槽是否开启
    public bool isRun;

    //能量槽满能量
    public float fullEnergy;

    //能量槽当前能量
    public float currentEnergy;

    //能量槽降低速率
    public float decreaseRate;

    //测试
    public TMP_Text EnergyBarText;
    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = fullEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        //检测是否暂停 - KeyCode Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isRun)
            {
                isRun = false;
            }
            else
            {
                isRun = true;
            }    
        }


        //检测能量槽是否降低
        if (isRun)
        {
            RunDecrease();
        }
        else
        {
            // 检测充能 - 目前用P键
            if (Input.GetKeyDown(KeyCode.P))
            {
                Refill();
            }
        }
        //测试功能
        EnergyBarText.text = currentEnergy.ToString("F1");
    }

    //能量槽减少
    public void RunDecrease()
    {
        if (currentEnergy > 0.0)
        {
            currentEnergy -= Time.deltaTime * decreaseRate;

            if (currentEnergy <= 0.0f)
            {
                currentEnergy = 0.0f;
            }
        }
    }

    //暂停游戏
    public void Pause()
    {
        isRun = false;
    }

    
    public void Refill()
    {
        currentEnergy = fullEnergy;
    }
}

