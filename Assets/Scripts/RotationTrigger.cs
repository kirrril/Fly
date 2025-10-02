using System;
using UnityEngine;

public class RotationTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform pivot;

    [SerializeField]
    private Vector3 axis;

    [SerializeField]
    private float angle;
    public event Action<Transform, Vector3, float> TriggerWorldRotation;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            TriggerWorldRotation?.Invoke(pivot, axis, angle);
        }

    }
}
