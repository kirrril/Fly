using UnityEngine;
using UnityEngine.InputSystem;

public class FlyMover : MonoBehaviour
{
    [SerializeField] private CharacterController flyController;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform flyLegs;
    private Vector2 moveInput;
    private Vector2 flyInput;
    Vector3 input;
    Vector3 headEuler;
    private Quaternion headRotation;
    private float speed = 1f;
    private Vector3 velocity;
    private float gravity = -0.1f;


    void Update()
    {
        headEuler = headRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, headEuler.y, 0);
        flyLegs.rotation = transform.rotation;
        mainCamera.localRotation = Quaternion.Euler(headEuler.x, 0, headEuler.z);

        input = new Vector3(moveInput.x, flyInput.y, moveInput.y).normalized;
        Vector3 move = flyLegs.TransformDirection(input) * speed * Time.deltaTime;

        transform.position = flyLegs.position - new Vector3(0, 0.08f, 0);

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

    public void OnFly(InputAction.CallbackContext ctx)
    {
        flyInput = ctx.ReadValue<Vector2>();
    }
}
