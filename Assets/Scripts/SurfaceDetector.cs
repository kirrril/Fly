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
            if (Physics.Raycast(transform.position, transform.up.normalized, out RaycastHit upHit, rayDistance, raycastMask))
            {
                FlyMover.isFlying = false;
                Rotate(upHit);
                return;
            }
            else if (Physics.Raycast(transform.position, (transform.up + transform.forward).normalized, out RaycastHit forwardUpHit, rayDistance, raycastMask))
            {
                FlyMover.isFlying = false;
                Rotate(forwardUpHit);
                return;
            }
            else if (Physics.Raycast(transform.position, (-transform.up + transform.forward).normalized, out RaycastHit frontForwardHit, rayDistance, raycastMask))
            {
                FlyMover.isFlying = false;
                // Debug.DrawRay(transform.position, (-transform.up + transform.forward).normalized * rayDistance, Color.green, 0.1f);
                Rotate(frontForwardHit);
                return;
            }
            else if (Physics.Raycast(frontRaycastOrigin.position, (-transform.up + -transform.forward).normalized, out RaycastHit frontBackwardHit, rayDistance * 0.5f, raycastMask))
            {
                FlyMover.isFlying = false;
                Rotate(frontBackwardHit);
                return;
            }
            else if (Physics.Raycast(transform.position, transform.forward.normalized, out RaycastHit straightForwardHit, rayDistance, raycastMask))
            {
                FlyMover.isFlying = false;
                Rotate(straightForwardHit);
                return;
            }
            else
            {
                FlyMover.isFlying = true;
                LevelToIdentity();
            }
        }
        else
        {
            if (Physics.Raycast(transform.position, (-transform.up + -transform.forward).normalized, out RaycastHit backBackwardHit, rayDistance, raycastMask))
            {
                FlyMover.isFlying = false;
                Rotate(backBackwardHit);
                return;
            }
            else if (Physics.Raycast(rearRaycastOrigin.position, (-transform.up + transform.forward).normalized, out RaycastHit backForwardHit, rayDistance * 0.5f, raycastMask))
            {
                FlyMover.isFlying = false;
                Rotate(backForwardHit);
                return;
            }
            else if (Physics.Raycast(frontRaycastOrigin.position, -transform.forward.normalized, out RaycastHit straightBackwardHit, rayDistance, raycastMask))
            {
                FlyMover.isFlying = false;
                Rotate(straightBackwardHit);
                return;
            }
            else if (Physics.Raycast(frontRaycastOrigin.position, (transform.up + -transform.forward).normalized, out RaycastHit backwardUpHit, rayDistance, raycastMask))
            {
                FlyMover.isFlying = false;
                Rotate(backwardUpHit);
                return;
            }
            else if (Physics.Raycast(transform.position, transform.up.normalized, out RaycastHit upHit, rayDistance, raycastMask))
            {
                FlyMover.isFlying = false;
                Rotate(upHit);
                return;
            }
            else
            {
                FlyMover.isFlying = true;
                LevelToIdentity();
            }
            //     if (Physics.Raycast(transform.position, (-transform.up + transform.forward).normalized, out RaycastHit frontForwardHit, rayDistance, raycastMask))
            //     {
            //         FlyMover.isFlying = false;
            //         // Debug.DrawRay(transform.position, (-transform.up + transform.forward).normalized * rayDistance, Color.green, 0.1f);
            //         Rotate(frontForwardHit);
            //         return;
            //     }
            //     else if (Physics.Raycast(frontRaycastOrigin.position, (-transform.up + -transform.forward).normalized, out RaycastHit frontBackwardHit, rayDistance * 0.5f, raycastMask))
            //     {
            //         FlyMover.isFlying = false;
            //         Rotate(frontBackwardHit);
            //         return;
            //     }
            //     else if (Physics.Raycast(transform.position, transform.forward.normalized, out RaycastHit straightForwardHit, rayDistance, raycastMask))
            //     {
            //         FlyMover.isFlying = false;
            //         Rotate(straightForwardHit);
            //         return;
            //     }
            //     else if (Physics.Raycast(transform.position, (transform.up + transform.forward).normalized, out RaycastHit forwardUpHit, rayDistance, raycastMask))
            //     {
            //         FlyMover.isFlying = false;
            //         Rotate(forwardUpHit);
            //         return;
            //     }
            //     else if (Physics.Raycast(transform.position, transform.up.normalized, out RaycastHit upHit, rayDistance, raycastMask))
            //     {
            //         FlyMover.isFlying = false;
            //         Rotate(upHit);
            //         return;
            //     }
            //     else
            //     {
            //         FlyMover.isFlying = true;
            //         LevelToIdentity();
            //     }
            // }
            // else
            // {
            //     if (Physics.Raycast(transform.position, (-transform.up + -transform.forward).normalized, out RaycastHit backBackwardHit, rayDistance, raycastMask))
            //     {
            //         FlyMover.isFlying = false;
            //         Rotate(backBackwardHit);
            //         return;
            //     }
            //     else if (Physics.Raycast(rearRaycastOrigin.position, (-transform.up + transform.forward).normalized, out RaycastHit backForwardHit, rayDistance * 0.5f, raycastMask))
            //     {
            //         FlyMover.isFlying = false;
            //         Rotate(backForwardHit);
            //         return;
            //     }
            //     else if (Physics.Raycast(frontRaycastOrigin.position, -transform.forward.normalized, out RaycastHit straightBackwardHit, rayDistance, raycastMask))
            //     {
            //         FlyMover.isFlying = false;
            //         Rotate(straightBackwardHit);
            //         return;
            //     }
            //     else if (Physics.Raycast(frontRaycastOrigin.position, (transform.up + -transform.forward).normalized, out RaycastHit backwardUpHit, rayDistance, raycastMask))
            //     {
            //         FlyMover.isFlying = false;
            //         Rotate(backwardUpHit);
            //         return;
            //     }
            //     else if (Physics.Raycast(transform.position, transform.up.normalized, out RaycastHit upHit, rayDistance, raycastMask))
            //     {
            //         FlyMover.isFlying = false;
            //         Rotate(upHit);
            //         return;
            //     }
            //     else
            //     {
            //         FlyMover.isFlying = true;
            //         LevelToIdentity();
            //     }
        }
    }

    void Rotate(RaycastHit hit)
    {
        Vector3 rotationAxis = Vector3.Cross(hit.normal, Vector3.up).normalized;
        float angle = Vector3.Angle(hit.normal, Vector3.up);
        sceneRoot.RotateAround(xrOrigin.position, rotationAxis, angle * Time.deltaTime * 10f);
    }

    void LevelToIdentity()
    {
        Vector3 currentUp = sceneRoot.up;
        Vector3 targetUp = Vector3.up;

        Vector3 rotationAxis = Vector3.Cross(currentUp, targetUp).normalized;
        float angle = Vector3.Angle(currentUp, targetUp);

        sceneRoot.RotateAround(xrOrigin.position, rotationAxis, angle * Time.deltaTime * 10f);
    }

}
