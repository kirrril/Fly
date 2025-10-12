using UnityEngine;
using UnityEngine.InputSystem;

public class FlyMover : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;

    private Vector2 moveInput;
    private Quaternion headRotation;
    private float speed = 2f;


    void Update()
    {
        Vector3 euler = headRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, euler.y, 0);
        mainCamera.localRotation = Quaternion.Euler(euler.x, 0, euler.z);

        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) * speed * Time.deltaTime;
        transform.Translate(move, Space.Self);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    public void OnRotate(InputAction.CallbackContext ctx)
    {
        headRotation = ctx.ReadValue<Quaternion>();
    }
}
