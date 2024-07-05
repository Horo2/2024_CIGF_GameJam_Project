using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoSingleton<SceneLoader>
{
    //预制件，自动实例化
    public GameObject transitionEffectPrefab;
    private TransitionEffect transitionEffect;

    protected override void OnStart()
    {
        base.OnStart();
        DontDestroyOnLoad(gameObject);
        InitializeTransitionEffect();
    }

    //自动实例化
    private void InitializeTransitionEffect()
    {
        transitionEffect = FindObjectOfType<TransitionEffect>();
        if (transitionEffect == null && transitionEffectPrefab != null)
        {
            GameObject instance = Instantiate(transitionEffectPrefab);
            transitionEffect = instance.GetComponent<TransitionEffect>();
        }
        if (transitionEffect == null)
        {
            Debug.LogError("TransitionEffect script not found in the scene.");
        }
    }

    public static IEnumerator LoadNewSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void LoadScene(string sceneName)
    {
        if (transitionEffect != null)
        {
            StartCoroutine(transitionEffect.PlayTransition(sceneName));
        }
        else
        {
            Debug.LogError("TransitionEffect not assigned.");
        }
    }
}
