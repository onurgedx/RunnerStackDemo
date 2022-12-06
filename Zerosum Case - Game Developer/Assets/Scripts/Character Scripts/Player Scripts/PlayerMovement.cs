using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(3)]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private PlayerData _playerData;

    [SerializeField] private Transform _playerAvatarModelTransform;

    public delegate void MovementDelegate();

    public MovementDelegate MovementEvent;

    private Transform _transform;

   

    public Action OnRun1MovementStart;
    public Action OnRun2MovementStart;

    public Action OnMovementEnd;
    


    private void Awake()
    {
        _transform = transform;

    }

    private void Start()
    {
      LevelManager.Instance.OnLevelStart += ActivateMoveAbilityRun1;
        LevelManager.Instance.OnLevelFinish += DeactivateMoveAbility;
    }
    private void Update()
    {

        Move();
        
    }

    #region Move Activate/Deactivate Methods
    private void ActivateMoveAbilityRun1()
    {

        OnRun1MovementStart?.Invoke();
        MovementEvent = MoveForwardRun1;


    }
    private void ActivateMoveAbilityRun2()
    {
        OnRun2MovementStart?.Invoke();
        MovementEvent = MoveForwardRun2;
    }
    private void DeactivateMoveAbility()
    {
        OnMovementEnd?.Invoke();
        MovementEvent = null;

    }
    #endregion


    #region Move Methods 
    private void MoveForwardRun1()
    {
        _transform.position += _playerAvatarModelTransform.forward * _playerData.Data.MovementSpeedForRun1 * Time.deltaTime;

    }

    private void MoveForwardRun2()
    {
        _transform.position += _playerAvatarModelTransform.forward * _playerData.Data.MovementSpeedForRun2 * Time.deltaTime;
    }
    #endregion


    #region Main Move Method
    private void Move()
    {
        MovementEvent?.Invoke();

    }
    #endregion


}
