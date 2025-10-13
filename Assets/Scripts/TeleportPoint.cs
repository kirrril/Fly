using System.Collections;
using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    [SerializeField] private Transform xrOrigin;
    [SerializeField] private Transform destination;
    [SerializeField] private float transitionTime = 1f;

    public void Teleport()
    {
        StartCoroutine(TeleportRoutine());

        Debug.Log("Teleport called");
    }

    private IEnumerator TeleportRoutine()
    {    
        Vector3 start = xrOrigin.position;
        float elapsed = 0f;

        while (elapsed < transitionTime)
        {
            float t = elapsed / transitionTime;
            xrOrigin.position = Vector3.Lerp(start, destination.position, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        xrOrigin.position = destination.position;
    }
}
