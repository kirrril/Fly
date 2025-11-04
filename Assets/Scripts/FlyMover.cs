using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Management;

public class FlyMover : MonoBehaviour
{
    [SerializeField] private CharacterController flyController;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform flyLegs;
    public Vector2 moveInput;
    private Vector2 flyInput;
    Vector3 input;
    Vector3 headEuler;
    private Quaternion headRotation;
    private Vector2 headRotationPC;
    public float speed;
    public float flyingSpeed;
    public float walkingSpeed;
    private Vector3 velocity;
    private float gravity = -0.01f;
    private float mouseSensitivity = 0.1f;
    private Vector2 mouseRotation;
    public static bool isFlying;

    void Start()
    {
        mouseRotation = new Vector2(mainCamera.eulerAngles.y, mainCamera.eulerAngles.x);
        flyingSpeed = 400f;
        walkingSpeed = 20f;
    }

    void Update()
    {
        speed = isFlying ? speed = flyingSpeed : speed = walkingSpeed;        

        bool isVR = XRGeneralSettings.Instance != null && XRGeneralSettings.Instance.Manager != null && XRGeneralSettings.Instance.Manager.activeLoader != null;

        if (isVR)
        {
            headEuler = headRotation.eulerAngles;
        }
        else
        {
            mouseRotation += headRotationPC * mouseSensitivity;
            mouseRotation.y = Mathf.Clamp(mouseRotation.y, -90f, 90f);
            headEuler = new Vector3(mouseRotation.y, mouseRotation.x, 0);
        }

        transform.rotation = Quaternion.Euler(0, headEuler.y, 0);
        mainCamera.localRotation = Quaternion.Euler(headEuler.x, 0, headEuler.z);

        input = new Vector3(moveInput.x, flyInput.y * 3, moveInput.y).normalized;
        Vector3 move = transform.TransformDirection(input) * speed * Time.deltaTime;

        if (flyInput.y <= 0)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0;
        }

        flyController.Move(move + velocity);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    public void OnRotate(InputAction.CallbackContext ctx)
    {
        headRotation = ctx.ReadValue<Quaternion>();
    }

    public void OnRotateOnPC(InputAction.CallbackContext ctx)
    {
        headRotationPC = ctx.ReadValue<Vector2>();
    }

    public void OnFly(InputAction.CallbackContext ctx)
    {
        flyInput = ctx.ReadValue<Vector2>();
    }
}
