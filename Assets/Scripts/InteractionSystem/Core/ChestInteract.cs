using UnityEngine;
using System.Collections;

public class ChestInteract : MonoBehaviour
{
    public GameObject itemInside;
    public float fadeDuration = 1.5f;

    private bool isOpening = false;

    private Renderer[] renderers;
    private Color[] originalColors;

    void Start()
    {
        // Get all renderers (including children)
        renderers = GetComponentsInChildren<Renderer>();

        // Store original colors
        originalColors = new Color[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            originalColors[i] = renderers[i].material.color;
        }
    }

    public void Interact()
    {
        if (!isOpening)
        {
            isOpening = true;
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        float time = 0f;
        bool itemShown = false;

        while (time < fadeDuration)
        {
            float progress = time / fadeDuration;
            float alpha = Mathf.Lerp(1f, 0f, progress);

            // Fade all parts of the chest
            for (int i = 0; i < renderers.Length; i++)
            {
                Color newColor = originalColors[i];
                newColor.a = alpha;
                renderers[i].material.color = newColor;
            }

            // ✅ Show item EARLY (faster feel)
            if (!itemShown && progress >= 0.3f)
            {
                itemInside.SetActive(true);

                // ✨ Optional: make item pop upward slightly
                itemInside.transform.position += Vector3.up * 0.5f;

                itemShown = true;
            }

            time += Time.deltaTime;
            yield return null;
        }

        // Ensure fully invisible
        for (int i = 0; i < renderers.Length; i++)
        {
            Color finalColor = originalColors[i];
            finalColor.a = 0f;
            renderers[i].material.color = finalColor;
        }

        // Destroy chest
        Destroy(gameObject);
    }
}