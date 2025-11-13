using UnityEngine;

public class FoodAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("isEaten", Eater.Instance.isEating);
    }
}
