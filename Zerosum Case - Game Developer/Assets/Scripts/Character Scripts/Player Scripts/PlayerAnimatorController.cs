using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{

    [SerializeField] private Animator _animator;


    



    private void AnimateIdle()
    {
        AnimateGivenEvent(AnimatorEvents.Idle);

    }

    private void AnimateRun1()
    {
        AnimateGivenEvent(AnimatorEvents.Run1);
    }
    private void AnimateRun2()
    {
        AnimateGivenEvent(AnimatorEvents.Run2);
    }

    private void AnimateDance()
    {
        AnimateGivenEvent(AnimatorEvents.Dance);
    }

    private void AnimateGivenEvent(int animationNumber)
    {
        _animator.SetTrigger(animationNumber);


    }





}
