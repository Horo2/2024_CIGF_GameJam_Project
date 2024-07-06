using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerController.Instance.Restrat();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneLoader.Instance.LoadScene("Test1");
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("检测到玩家");
            SceneLoader.Instance.LoadScene("PauseMenuTest");
        }
    }
}