using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraManager : MonoSingleton<CameraManager>
{
    public float CameraMovemenSpeed = 3f;
    public float CameraRotateSpeed = 2f;
    public Action CameraEvents;


    private Camera _mainCamera;
    private Transform _cameraReferanceTransform;






    // Start is called before the first frame update
    void Start()
    {

        _mainCamera = Camera.main;
        SetCameraEvents();


    }

    // Update is called once per frame
    void LateUpdate()
    {

        CameraEvents?.Invoke();


    }

    #region Camera Referance Setter
    public void SetCameraReferance(Transform referanceTransform)
    {
        _cameraReferanceTransform = referanceTransform;
    }
    #endregion

    #region CameraEvents Handler
    public void SetCameraEvents()
    {
        CameraEvents = CameraMovementGeneral;
        CameraEvents += CameraRotateGeneral;

    }
    #endregion

    #region Camera Movements
    private void CameraMovementGeneral()
    {
        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _cameraReferanceTransform.position, CameraMovemenSpeed * Time.deltaTime);

    }
    private void CameraRotateGeneral()
    {

        _mainCamera.transform.rotation = Quaternion.Lerp(_mainCamera.transform.rotation, _cameraReferanceTransform.rotation, CameraRotateSpeed * Time.deltaTime);


    }
    #endregion

    #region CameraShake Method
    public void ShakeCamera()
    {

        _mainCamera.transform.DOShakeRotation(Durations.CameraShakeDuration, 5, 3);

    }
    #endregion


}
