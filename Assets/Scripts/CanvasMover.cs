using UnityEngine;

public class CanvasMover : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;

    private Vector3 canvasPosition;
    private Vector3 distance;

    void Start()
    {
        canvasPosition = transform.position;
        distance = canvasPosition - mainCamera.transform.position;
    }

    void Update()
    {
        transform.position = mainCamera.transform.position + distance;
    }
}
