using UnityEngine;
using UnityEngine.InputSystem;

public class FlyMover : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform flyLegs;
    private Vector2 moveInput;
    private Vector3 moveHeadInput;
    private Vector2 flyInput;
    private Quaternion headRotation;
    private float speed = 1f;

    void Start()
    {
        transform.position = new Vector3 (0, 0, 0);
    }


    void Update()
    {
        Vector3 euler = headRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, euler.y, 0);
        flyLegs.rotation = Quaternion.Euler(0, euler.y, 0);
        mainCamera.localRotation = Quaternion.Euler(euler.x, 0, euler.z);


        // float flyInputY = flyInput.y;
        Vector3 move = new Vector3(moveInput.x + moveHeadInput.x, flyInput.y * 5, moveInput.y + moveHeadInput.z).normalized * speed * Time.deltaTime;
        transform.Translate(move, Space.Self);

        Vector3 originPosition = transform.position;
        flyLegs.position = new Vector3(originPosition.x, originPosition.y - 0.1f, originPosition.z);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    public void OnMoveHead(InputAction.CallbackContext ctx)
    {
        moveHeadInput = ctx.ReadValue<Vector3>();
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
