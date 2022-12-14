using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(0)]
public class PlayerAnimatorController : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    [SerializeField] private PlayerMovement _playerMovement;


    private void Start()
    {
        
        LevelManager.Instance.OnLevelLoad += AnimateIdle;
        
        _playerMovement.OnMovementEnd += AnimateDance;
        
        _playerMovement.OnRun1MovementStart += AnimateRun1;
        
        _playerMovement.OnRun2MovementStart += AnimateRun2;

    }
    #region Animation Runners
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
    #endregion

    #region Base Animation Runner
    private void AnimateGivenEvent(int animationNumber)
    {
        _animator.ResetTrigger(AnimatorEvents.Dance);
        _animator.ResetTrigger(AnimatorEvents.Run1);
        _animator.ResetTrigger(AnimatorEvents.Run2);
        _animator.ResetTrigger(AnimatorEvents.Idle);

        _animator.SetTrigger(animationNumber);


    }

    #endregion



}
