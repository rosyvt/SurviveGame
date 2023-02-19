using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uninteruptable : StateMachineBehaviour
{
    [Range(0, 1)]
    public float startTime;
    [Range(0, 1)]
    public float endTime;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float currentTime = stateInfo.normalizedTime;
        if (currentTime >= startTime && currentTime <= endTime)
        {
            animator.SetBool("Interuptable", false);
        }
        else
        {
            animator.SetBool("Interuptable", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Interuptable", true);
    }
}
