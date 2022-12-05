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

    public Action OnMovementEnd;
    


    private void Awake()
    {
        _transform = transform;

    }

    private void Start()
    {
      LevelManager.Instance.OnLevelStart += ActivateMoveAbility;
        LevelManager.Instance.OnLevelFinish += DeactivateMoveAbility;
    }
    private void Update()
    {

        Move();
        
    }

    #region Move Activate/Deactivate Methods
    private void ActivateMoveAbility()
    {

        OnRun1MovementStart?.Invoke();
        MovementEvent = MoveForward;


    }
    private void DeactivateMoveAbility()
    {
        OnMovementEnd?.Invoke();
        MovementEvent = null;

    }
    #endregion


    #region Move Methods 
    private void MoveForward()
    {
        _transform.position += _playerAvatarModelTransform.forward * _playerData.Data.MovementSpeedForRun1 * Time.deltaTime;

    }
    #endregion


    #region Main Move Method
    private void Move()
    {
        MovementEvent?.Invoke();

    }
    #endregion


}
