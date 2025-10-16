using System.Collections;
using UnityEngine;

public class CeilingRotator : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TurnCeiling());
    }

    void OnTriggerExit(Collider other)
    {
        StartCoroutine(TurnCeiling());
    }

    private IEnumerator TurnCeiling()
    {
        yield return new WaitForSeconds(0.5f);

        Quaternion startRotation = transform.rotation;
        Quaternion upSideDown = Quaternion.Euler(0, 180, 0);

        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            transform.rotation = Quaternion.Slerp(startRotation, upSideDown, t);
            yield return null;
        }

        transform.rotation = upSideDown;
    }
}
