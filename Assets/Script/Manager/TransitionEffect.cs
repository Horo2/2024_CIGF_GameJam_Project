using System.Collections;
using UnityEngine;

public class TransitionEffect : MonoSingleton<TransitionEffect>
{
    public RectTransform transitionRect;
    public float transitionDuration = 1.0f;
    private Vector3 offScreenLeft = new Vector3(-1746, 0, 0);
    private Vector3 offScreenRight = new Vector3(1750, 0, 0);
    private Vector3 onScreen = Vector3.zero;

    protected override void OnStart()
    {
        transitionRect.anchoredPosition = offScreenLeft;
        base.OnStart();
    }

    public IEnumerator PlayTransition(string sceneName)
    {
        // Move the rectangle from left to center
        yield return StartCoroutine(MoveBlackScreen(offScreenLeft, onScreen, transitionDuration));

        // Load the new scene asynchronously
        yield return StartCoroutine(SceneLoader.LoadNewSceneAsync(sceneName));

        // spawn Player
        Vector2 spawnPosition = SceneLoader.Instance.GetSpawnPointPosition();
        PlayerController.Instance.UpdatePlayerPosition(spawnPosition);

        // Move the rectangle from center to right
        yield return StartCoroutine(MoveBlackScreen(onScreen, offScreenRight, transitionDuration));
    }

    //移动BlackScreen
    private IEnumerator MoveBlackScreen(Vector3 startPos, Vector3 endPos, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            transitionRect.localPosition = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transitionRect.localPosition = endPos;
    }
}
