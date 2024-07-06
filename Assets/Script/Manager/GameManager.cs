using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanelPrefab; // 预制件
    private GameObject gameOverPanelInstance; // 预制件的实例

    private void Start()
    {
        //InstantiateGameOverPanel();
    }

    public void Update()
    {
        //if (gameOverPanelInstance == null)
        //{
        //    Debug.LogWarning("GameOverPanel instance is null in Update.");
        //    InstantiateGameOverPanel();
        //}
            // 检测按下 ESC 键
            if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleGameOverPanel();
        }
    }

    // 切换游戏结束面板的激活状态
    private void ToggleGameOverPanel()
    {
        if (gameOverPanelInstance != null)
        {
            bool newState = !gameOverPanelInstance.activeSelf;
            gameOverPanelInstance.SetActive(newState);
            Debug.Log("GameOverPanel instance active state set to: " + newState);
        }
        else
        {
            Debug.LogError("GameOverPanel instance is null!");
        }
    }

    // 开始游戏，加载第一个场景
    public void StartGame()
    {
        CloseGameOverPanel();
        SceneLoader.Instance.LoadScene("SampleScene");
    }

    // 退出游戏
    public void QuitGame()
    {
        Application.Quit();
    }

    



    // 实例化游戏结束面板
    //private void InstantiateGameOverPanel()
    //{
    //    Canvas canvas = GameObject.Find("UIMain").GetComponent<Canvas>(); ; // 查找场景中的 Canvas
    //    if (canvas != null)
    //    {
    //        Debug.Log("Find canvas");
    //        // 实例化预制件并将其设置为非激活状态，并设置父对象为 Canvas
    //        gameOverPanelInstance = Instantiate(GameOverPanelPrefab, canvas.transform);
    //        gameOverPanelInstance.SetActive(false);
    //    }
    //    else
    //    {
    //        Debug.LogError("No Canvas found in the scene.");
    //    }
    //}

    // 关闭游戏结束面板
    private void CloseGameOverPanel()
    {
        if (gameOverPanelInstance != null)
        {
            gameOverPanelInstance.SetActive(false);
        }
        else
        {
            Debug.LogError("GameOverPanel instance is null!");
        }
    }

}
