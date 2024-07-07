using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoSingleton<SceneLoader>
{
    //预制件，自动实例化
    public GameObject transitionEffectPrefab;
    private TransitionEffect transitionEffect;

    // 记录当前能量条
    public static float currentEnergyVolume;

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
       if (sceneName != SceneManager.GetActiveScene().name)
        {
            currentEnergyVolume = EnergyBar.GetCurrentEnergy();
        }
        Debug.Log("记录当前能量：" + currentEnergyVolume);
        if (transitionEffect != null)
        { 
            StartCoroutine(transitionEffect.PlayTransition(sceneName));
        }
        else
        {
            Debug.LogError("TransitionEffect not assigned.");
        }
    }

    public Vector2 GetSpawnPointPosition()
    {
        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        if (spawnPoint != null)
        {
            Debug.Log("SpwanPoint Position: " + spawnPoint.transform.position);
            return spawnPoint.transform.position;
        }
        return Vector2.zero;
    }
}
