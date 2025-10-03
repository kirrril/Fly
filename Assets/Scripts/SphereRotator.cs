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

    // private IEnumerator RotatingSpace(float angle)
    // {
    //     float rotatedAngle = 0f;

    //     Quaternion startRotation = space.rotation;

    //     while (rotatedAngle < Mathf.Abs(angle))
    //     {
    //         float step = rotationSpeed * Time.deltaTime;
    //         if (rotatedAngle + step > Mathf.Abs(angle))
    //             step = Mathf.Abs(angle) - rotatedAngle;

    //         space.RotateAround(flyLegs.position, flyLegs.right, Mathf.Sign(angle) * step);
    //         rotatedAngle += step;

    //         yield return null;
    //     }

    //     space.rotation = space.rotation;
    // }

    private IEnumerator RotatingSpace(float angle)
    {
        Quaternion startRotation = space.rotation; // rotation de départ
        Quaternion targetRotation = startRotation * Quaternion.AngleAxis(angle, flyLegs.right);

        float elapsed = 0f;
        float duration = Mathf.Abs(angle) / rotationSpeed; // durée totale en secondes

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            space.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        // s’assure que la rotation finale est exactement la cible
        space.rotation = targetRotation;
    }
}
