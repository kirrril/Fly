using System;
using System.Collections;
using UnityEngine;

public class SphereRotator : MonoBehaviour
{
    [SerializeField] private Transform space;
    [SerializeField] private Transform flyLegs;
    [SerializeField] private float rotationAngle;
    private float rotationSpeed = 180f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            StartCoroutine(RotatingSpace(rotationAngle));
        }
    }

    private IEnumerator RotatingSpace(float angle)
    {
        Quaternion startRotation = space.rotation;
        Quaternion targetRotation = startRotation * Quaternion.AngleAxis(angle, flyLegs.right);

        float elapsed = 0f;
        float duration = Mathf.Abs(angle) / rotationSpeed;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            space.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        space.rotation = targetRotation;
    }
}
