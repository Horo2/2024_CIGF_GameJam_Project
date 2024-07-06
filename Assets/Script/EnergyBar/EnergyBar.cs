using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnergyBar : MonoSingleton<EnergyBar>
{
    //能量槽是否开启
    public bool isDisabled;

    //能量槽满能量
    public float fullEnergy;

    //能量槽当前能量
    public float currentEnergy;

    //能量槽降低速率
    public float decreaseRate;

    //加的能量
    public float addEnergy;

    //测试UI
    [SerializeField] private GameObject EnergyBarAll;
    [SerializeField] private TMP_Text EnergyBarText;
    [SerializeField] private Slider EnergyBarUI;

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = fullEnergy;
        EnergyBarText = GameObject.Find("EnergyBarText").GetComponent<TMP_Text>();
        EnergyBarUI = GameObject.Find("EnergyBarUI").GetComponent<Slider>();
        EnergyBarUI.value = 1;
        isDisabled = true;
        checkIfMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfMainMenu();
        isDisabled = PlayerController.GetisDisable();
        //检测能量槽是否降低
        //Debug.Log("isDisabled" + isDisabled);
        if (!isDisabled)
        {
            RunDecrease();
        }
        /*
        else
        {
            // 检测充能 - 目前用P键
            if (Input.GetKeyDown(KeyCode.P))
            {
                Refill();
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                AddEnergy();
            }
        }*/
        //测试功能
        EnergyBarText.text = $"{currentEnergy.ToString("F1")}/{fullEnergy.ToString("F1")}";
        UpdateEnergyBarUI();
        //Debug.Log("CurrentEnergy" + currentEnergy);
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

    // 更新UI
    public void UpdateEnergyBarUI()
    {
        if (EnergyBarUI != null)
        {
            float sliderTimerValue = currentEnergy / fullEnergy;
            EnergyBarUI.value = sliderTimerValue;
        }
    }

    //暂停游戏
    public void Pause()
    {
        isDisabled = true;
    }

    public void Refill()
    {
        currentEnergy = fullEnergy;
    }

    public void AddEnergy()
    {
        currentEnergy += addEnergy;
    }

    public void checkIfMainMenu()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("currentScene : " + currentScene.name);
        if (currentScene.name == "Menu")
        {
            if (EnergyBarAll != null)
            {
                Debug.Log("Disabling EnergyBarAll");
                EnergyBarAll.SetActive(false);
            }
        }
        else
        {
            EnergyBarAll.SetActive(true);

        }
            
        
    }

}

