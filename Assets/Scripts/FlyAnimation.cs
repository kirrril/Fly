using UnityEngine;

public class FlyAnimation : MonoBehaviour
{
    [SerializeField] private Transform xrOrigin;
    [SerializeField] private Animator animator;
    private Vector3 lastPosition;
    private float lastYaw;

    void Start()
    {
        lastPosition = xrOrigin.position;
        lastYaw = xrOrigin.eulerAngles.y;
    }

    void Update()
    {
        Vector3 delta = xrOrigin.position - lastPosition;
        Vector3 flatDelta = new Vector3(delta.x, 0, delta.z);
        Vector3 verticalDelta = new Vector3(0, delta.y, 0);
        float up = verticalDelta.magnitude / Time.deltaTime;
        float forward = flatDelta.magnitude / Time.deltaTime;

        float currentYaw = xrOrigin.eulerAngles.y;
        float turn = Mathf.DeltaAngle(lastYaw, currentYaw) / Time.deltaTime;

        if (up > 0.1)
        {
            animator.SetFloat("up", up);
        }
        else
        {
            animator.SetFloat("up", 0);

            animator.SetFloat("forward", forward);

            if (forward < 0.1f && turn > 0.1f)
            {
                animator.SetFloat("turn", turn);
            }
            else
            {
                animator.SetFloat("turn", 0f);
            }

        }

        lastPosition = xrOrigin.position;
        lastYaw = currentYaw;
    }
}
