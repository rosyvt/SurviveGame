using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class AdjustAnimatorSpeed : StateMachineBehaviour
{
    public float speed;
    public float fromTime;
    public float toTime;
    public string callbackInDuration;
    public string normalCallback;
    CallbackRegistry callbackRegistry;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        callbackRegistry = animator.GetComponent<CallbackRegistry>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= toTime)
        {
            animator.speed = 1;
            ExecuteCallback(normalCallback);
        }
        else if (stateInfo.normalizedTime >= fromTime)
        {
            animator.speed = speed;
            ExecuteCallback(callbackInDuration);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = 1;
        ExecuteCallback(normalCallback);
    }

    void ExecuteCallback(string name)
    {
        if (callbackRegistry != null)
        {
            General.Callback callback = callbackRegistry.GetCallbackWithName(name);
            if (callback != null)
            {
                callback.action();
            }
        }
    }
}
