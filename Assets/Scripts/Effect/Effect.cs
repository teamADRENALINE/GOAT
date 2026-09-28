using UnityEngine;

public class Effect : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        // アニメーションが1周したら削除
        if (state.normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }
}