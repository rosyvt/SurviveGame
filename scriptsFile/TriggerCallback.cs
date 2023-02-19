using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

public class TriggerCallback : StateMachineBehaviour
{
    public float time;
    public string callbackName;
    public AnimationState triggerIn;
    bool isTriggered;
    CallbackRegistry callbackRegistry;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        callbackRegistry = animator.GetComponent<CallbackRegistry>();
        isTriggered = false;
        if (triggerIn == AnimationState.Enter)
        {
            ExecuteCallback(callbackName);
        }
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (triggerIn == AnimationState.Update && isTriggered == false && stateInfo.normalizedTime >= time)
        {
            ExecuteCallback(callbackName);
            isTriggered = true;
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isTriggered = false;
        if (triggerIn == AnimationState.Exit)
        {
            ExecuteCallback(callbackName);
        }
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
