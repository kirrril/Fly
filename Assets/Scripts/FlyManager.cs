using UnityEngine;

public class FlyManager : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;

    private Vector3 legsPosition;
    private Vector3 distance;

    void Start()
    {
        legsPosition = transform.position;
        distance = legsPosition - mainCamera.transform.position;
    }

    void Update()
    {
        transform.position = mainCamera.transform.position + distance;

        Vector3 legsEuler = transform.eulerAngles;
        legsEuler.y = mainCamera.eulerAngles.y;
        transform.eulerAngles = legsEuler;
    }
}
