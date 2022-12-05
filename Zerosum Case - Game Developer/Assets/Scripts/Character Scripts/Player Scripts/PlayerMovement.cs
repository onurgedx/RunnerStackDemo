using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private PlayerData _playerData;

    public delegate void MovementDelegate();

    public MovementDelegate MovementEvent;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;

    }
    
    private void Update()
    {

        Move();
        
    }

    #region Move Activate/Deactivate Methods
    private void ActivateMoveAbility()
    {
        MovementEvent = MoveForward;
    }
    private void DeactivateMoveAbility()
    {
        MovementEvent = null;

    }
    #endregion


    #region Move Methods 
    private void MoveForward()
    {
        _transform.position += _transform.forward * _playerData.Data.MovementSpeedForRun1 * Time.deltaTime;

    }
    #endregion


    #region Main Move Method
    private void Move()
    {
        MovementEvent?.Invoke();

    }
    #endregion


}
