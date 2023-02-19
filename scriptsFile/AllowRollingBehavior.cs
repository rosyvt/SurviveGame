using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowRollingBehavior : StateMachineBehaviour
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetBehaviour<RollBehavior>().EnableRolling(true);
    }
}
