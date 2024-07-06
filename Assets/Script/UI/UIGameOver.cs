using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameOver : UIWindow
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ���¿�ʼ��Ϸ
    public void OnClickRestart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneLoader.Instance.LoadScene(currentScene.name);
        this.Close();
    }

    public void OnClickSetting()
    {

    }

    // �������˵�
    public void OnClickMainMenu()
    {
        SceneLoader.Instance.LoadScene("Menu");
        this.Close();
    }
}
