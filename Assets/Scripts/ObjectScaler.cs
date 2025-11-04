using UnityEngine;
using System.Collections;

public class ObjectScaler : MonoBehaviour
{
    [SerializeField] private Transform objectToScale;
    [SerializeField] private float scaleFactor;
    private Vector3 originalScale;
    private Coroutine scaleCoroutine;
    private float duration = 0.8f;

    void OnEnable()
    {
        originalScale = objectToScale.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopScaling();
            scaleCoroutine = StartCoroutine(ScaleTo(originalScale * scaleFactor));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopScaling();
            scaleCoroutine = StartCoroutine(ScaleTo(originalScale));
        }
    }

    private void StopScaling()
    {
        if (scaleCoroutine != null) StopCoroutine(scaleCoroutine);
    }

    private IEnumerator ScaleTo(Vector3 targetScale)
    {
        Vector3 startScale = objectToScale.localScale;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            objectToScale.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        objectToScale.localScale = targetScale;
    }
}
