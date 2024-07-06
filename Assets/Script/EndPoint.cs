using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                string nextScenePath = SceneUtility.GetScenePathByBuildIndex(nextSceneIndex);
                string nextSceneName = System.IO.Path.GetFileNameWithoutExtension(nextScenePath);
                SceneLoader.Instance.LoadScene(nextSceneName);
            }
        }
    }
}
