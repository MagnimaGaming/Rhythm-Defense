using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void LeftLegUP()
    {
        animator.SetTrigger("leftLegUp");
    }

    public void LeftLegDown()
    {
        animator.SetTrigger("leftLegDown");
    }

    public void RightLegUP()
    {
        animator.SetTrigger("rightLegUp");
    }

    public void RightLegDown()
    {
        animator.SetTrigger("rightLegDown");
    }
}
