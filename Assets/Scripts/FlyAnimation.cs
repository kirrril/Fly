using UnityEditor.Animations;
using UnityEngine;

public class FlyAnimation : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Animator animator;
    private Vector3 lastPosition;
    private float lastYaw;

    void Start()
    {
        lastPosition = mainCamera.position;
        lastYaw = mainCamera.eulerAngles.y;
    }

    void Update()
    {
        Vector3 delta = mainCamera.position - lastPosition;
        Vector3 flatDelta = new Vector3(delta.x, 0, delta.z);
        float forward = flatDelta.magnitude / Time.deltaTime;

        float currentYaw = mainCamera.eulerAngles.y;
        float turn = Mathf.DeltaAngle(lastYaw, currentYaw) / Time.deltaTime;

        animator.SetFloat("forward", forward);

        if (forward < 0.01f)
        {
            animator.SetFloat("turn", turn);
        }
        else
        {
            animator.SetFloat("turn", 0f);
        }


        lastPosition = mainCamera.position;
        lastYaw = currentYaw;
    }
}
