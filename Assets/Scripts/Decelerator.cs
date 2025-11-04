using UnityEngine;

public class Decelerator : MonoBehaviour
{
    private FlyMover flyMover;
    [SerializeField] private float localFlyingSpeed;
    [SerializeField] private float localWalkingSpeed;
    [SerializeField] private float previousFlyingSpeed;
    [SerializeField] private float previousWalkingSpeed;

    void OnEnable()
    {
        flyMover = GameObject.Find("XR Origin").GetComponent<FlyMover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flyMover.flyingSpeed = localFlyingSpeed;
            flyMover.walkingSpeed = localWalkingSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flyMover.flyingSpeed = previousFlyingSpeed;
            flyMover.walkingSpeed = previousWalkingSpeed;
        }
    }
}
