using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBehavior : StateMachineBehaviour
{
    public float speed;
    bool shouldRoll = true;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (shouldRoll == false)
        {
            animator.SetInteger("Dodge", 0);
            return;
        }
        animator.transform.position =
            animator.transform.position + animator.transform.forward * speed * Time.deltaTime;
    }

    public void EnableRolling(bool enabled)
    {
        shouldRoll = enabled;
    }
}
