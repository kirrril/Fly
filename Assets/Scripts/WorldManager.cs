using System;
using System.Collections;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private Transform worldRoot;
    [SerializeField] RotationTrigger[] rotationTriggers;

    private float rotationSpeed = 180f;
    private bool rotating = false;

    private void Start()
    {
        foreach (RotationTrigger trigger in rotationTriggers)
        {
            trigger.TriggerWorldRotation += RotateWorld;
        }
    }

    private void RotateWorld(Transform pivot, Vector3 axis, float angle)
    {
        if (!rotating) StartCoroutine(RotatingWorld(pivot, axis, angle));
    }

    private IEnumerator RotatingWorld(Transform pivot, Vector3 rotationAxis, float rotationAngle)
    {
        rotating = true;

        float rotatedAngle = 0f;

        while (rotatedAngle < Mathf.Abs(rotationAngle))
        {
            float step = rotationSpeed * Time.deltaTime;
            if (rotatedAngle + step > Mathf.Abs(rotationAngle))
                step = Mathf.Abs(rotationAngle) - rotatedAngle;

            worldRoot.RotateAround(pivot.position, rotationAxis, Mathf.Sign(rotationAngle) * step);
            rotatedAngle += step;

            yield return null;
        }

        rotating = false;
    }
}
