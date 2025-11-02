using UnityEngine;

public class SurfaceDetector : MonoBehaviour
{
    [SerializeField] private FlyMover flyMover;
    [SerializeField] private Transform sceneRoot;
    [SerializeField] private Transform xrOrigin;
    [SerializeField] private Transform frontRaycastOrigin;
    [SerializeField] private Transform rearRaycastOrigin;
    private float rayDistance = 0.5f;
    private LayerMask raycastMask;

    void Start()
    {
        raycastMask = ~LayerMask.GetMask("Ignore Raycast");
    }

    void Update()
    {
        if (flyMover.moveInput.y >= 0)
        {
            if (Physics.Raycast(transform.position, (-transform.up + transform.forward).normalized, out RaycastHit frontForwardHit, rayDistance, raycastMask))
            {
                FlyMover.isFlying = false;
                Debug.DrawRay(transform.position, (-transform.up + transform.forward).normalized * rayDistance, Color.green, 0.1f);
                Rotate(frontForwardHit);
                return;
            }
            else if (Physics.Raycast(frontRaycastOrigin.position, (-transform.up + -transform.forward).normalized, out RaycastHit frontBackwardHit, rayDistance * 0.5f, raycastMask))
            {
                FlyMover.isFlying = false;
                Debug.DrawRay(frontRaycastOrigin.position, (-transform.up + -transform.forward).normalized * rayDistance, Color.yellow, 0.1f);
                Rotate(frontBackwardHit);
                return;
            }
            else FlyMover.isFlying = true;
        }
        else
        {
            if (Physics.Raycast(transform.position, (-transform.up + -transform.forward).normalized, out RaycastHit backBackwardHit, rayDistance, raycastMask))
            {
                FlyMover.isFlying = false;
                Debug.DrawRay(transform.position, (-transform.up + -transform.forward).normalized * rayDistance, Color.red, 0.1f);
                Rotate(backBackwardHit);
                return;
            }
            else if (Physics.Raycast(rearRaycastOrigin.position, (-transform.up + transform.forward).normalized, out RaycastHit backForwardHit, rayDistance * 0.5f, raycastMask))
            {
                FlyMover.isFlying = false;
                Debug.DrawRay(rearRaycastOrigin.position, (-transform.up + -transform.forward).normalized * rayDistance, Color.cyan, 0.1f);
                Rotate(backForwardHit);
                return;
            }
            else FlyMover.isFlying = true;
        }

        void Rotate(RaycastHit hit)
        {
            Vector3 rotationAxis = Vector3.Cross(hit.normal, Vector3.up).normalized;
            float angle = Vector3.Angle(hit.normal, Vector3.up);
            sceneRoot.RotateAround(xrOrigin.position, rotationAxis, angle * Time.deltaTime * 10f);
        }
    }
}
