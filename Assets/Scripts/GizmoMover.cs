using UnityEngine;

public class GizmoMover : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private Vector3 gizmoPosition;
    private Vector3 distance;

    void Start()
    {
        gizmoPosition = transform.position;
        distance = gizmoPosition - canvas.transform.position;
    }

    void Update()
    {
        transform.position = canvas.transform.position + distance;
    }
}
