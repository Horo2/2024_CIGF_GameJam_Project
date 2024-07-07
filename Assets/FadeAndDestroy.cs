using UnityEngine;

public class FadeAndDestroy : MonoBehaviour
{
    public float fadeDuration = 2.0f; // Duration in seconds to become fully transparent

    private Renderer objectRenderer;
    private Color originalColor;
    private float fadeSpeed;
    private float currentFadeTime = 0f;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogError("No Renderer found on the object.");
            return;
        }

        originalColor = objectRenderer.material.color;
        fadeSpeed = 1.0f / fadeDuration;
    }

    void Update()
    {
        if (objectRenderer != null)
        {
            currentFadeTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1.0f, 0.0f, currentFadeTime * fadeSpeed);
            Color newColor = originalColor;
            newColor.a = alpha;
            objectRenderer.material.color = newColor;

            if (alpha <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
