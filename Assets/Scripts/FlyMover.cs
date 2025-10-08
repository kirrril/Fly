using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class FlyMover : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;

    private Vector2 moveInput;
    private Vector2 lookAngles;
    private Vector2 currentRotation;
    private Quaternion lookGyroInput;
    private float speed = 2f;
    private float lookSensivity = 0.5f;
    private bool isVR;
    private bool useGyro = false;

    void Start()
    {
        if (!isVR && !useGyro)
        {
            isVR = XRSettings.isDeviceActive;
            mainCamera.localRotation = Quaternion.identity;
        }
    }

    void Update()
    {
        if (useGyro)
        {
            transform.rotation = Quaternion.Euler(0, lookGyroInput.eulerAngles.y, 0);
            mainCamera.localRotation = Quaternion.Euler(-lookGyroInput.eulerAngles.x, 0, 0);
        }
        else if (!isVR && !useGyro)
        {
            currentRotation.x += lookAngles.x * lookSensivity;
            currentRotation.y += lookAngles.y * lookSensivity;
            currentRotation.y = Mathf.Clamp(currentRotation.y, -40f, 80f);
            transform.rotation = Quaternion.Euler(0, currentRotation.x, 0);
            mainCamera.localRotation = Quaternion.Euler(-currentRotation.y, 0, 0);
        }

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) * speed * Time.deltaTime;
        transform.Translate(move, Space.Self);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        useGyro = false;
        lookAngles = ctx.ReadValue<Vector2>();
    }

    public void OnLookGyro(InputAction.CallbackContext ctx)
    {
        useGyro = true;
        lookGyroInput = ctx.ReadValue<Quaternion>();
    }
}
