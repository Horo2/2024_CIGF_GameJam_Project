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

    // 重新开始游戏
    public void OnClickRestart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        this.Close();
    }

    public void OnClickSetting()
    {

    }

    // 返回主菜单
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
        this.Close();
    }
}
