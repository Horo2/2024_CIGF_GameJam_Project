using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneLoader.Instance.LoadScene("SampleScene");
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