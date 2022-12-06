using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraReferanceSetter : MonoBehaviour
{

    
    [SerializeField] private Transform _cameraReferanceBeforeStart, _cameraReferanceRun1, _cameraReferanceRun2, _cameraReferanceDance;


    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerDancer _playerDancer;

    private void Start()
    {
        SetCameraReferanceBeforeStart();
        _playerMovement.OnRun1MovementStart += SetCameraReferanceRun1;
        _playerMovement.OnRun2MovementStart += SetCameraReferanceRun2;
        _playerDancer.OnDanceStart += SetCameraReferanceDance;

    }

    private void SetCameraReferanceGivenTransform(Transform referanceTransform)
    {

        CameraManager.Instance.SetCameraReferance(referanceTransform);

    }


    private void SetCameraReferanceBeforeStart()
    {
        SetCameraReferanceGivenTransform(_cameraReferanceBeforeStart);
    }

    private void SetCameraReferanceRun1()
    {
        SetCameraReferanceGivenTransform(_cameraReferanceRun1);
    }

    private void SetCameraReferanceRun2()
    {
        SetCameraReferanceGivenTransform(_cameraReferanceRun2);
    }

    private void SetCameraReferanceDance()
    {
        SetCameraReferanceGivenTransform(_cameraReferanceDance);
    }

}
