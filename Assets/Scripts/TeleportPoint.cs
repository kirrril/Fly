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
    }

    private IEnumerator TeleportRoutine()
    {
        Debug.Log("Coroutine started");
        
        Vector3 start = xrOrigin.position;
        // Quaternion startRot = xrOrigin.rotation;
        float elapsed = 0f;

        while (elapsed < transitionTime)
        {
            float t = elapsed / transitionTime;
            xrOrigin.position = Vector3.Lerp(start, destination.position, t);
            // xrOrigin.rotation = Quaternion.Slerp(startRot, destination.rotation, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        xrOrigin.position = destination.position;
        // xrOrigin.rotation = destination.rotation;
    }
}
