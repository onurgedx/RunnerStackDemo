using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatarRotater : MonoBehaviour
{

    
    [SerializeField] private Transform _playerAvatarTransform;
    [SerializeField] private Transform _playerAvatarLookHereTransform;
    [SerializeField] private PlayerData _playerData;
    


    public delegate void RotateDelegate();

    public RotateDelegate RotateEvent;



    private void Update()
    {

        Rotate();

    }

    #region Main Rotate Method

    private void Rotate()
    {
        RotateEvent?.Invoke();

    }
    #endregion


    #region Rotate Methods
    private void RotateToReferance()
    {

        Quaternion destinationRotation = Quaternion.LookRotation(_playerAvatarLookHereTransform.position - _playerAvatarTransform.position);
        _playerAvatarTransform.rotation = Quaternion.Lerp(_playerAvatarTransform.rotation , destinationRotation , Time.deltaTime * _playerData.Data.RotateSpeed);

    }
    #endregion

    #region Rotate Activate/Deactivate  Methods

    private void ActivateRotate()
    {
        RotateEvent = RotateToReferance;

    }

    private void DeactivateRotate()
    {
        RotateEvent = null;

    }

    #endregion






}
