using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{

    
    private Camera _mainCamera;

    private Transform _cameraReferanceTransform;


    public float CameraMovemenSpeed = 3f;
    public float CameraRotateSpeed = 2f;

    public Action CameraEvents;




    // Start is called before the first frame update
    void Start()
    {

        _mainCamera = Camera.main;
        SetCameraEvents();


    }

    // Update is called once per frame
    void Update()
    {

        CameraEvents?.Invoke();

        
    }

   public void SetCameraReferance(Transform referanceTransform)
    {
        _cameraReferanceTransform = referanceTransform;
    }


    public void SetCameraEvents()
    {
        CameraEvents = CameraMovementBeforeStart;
        CameraEvents += CameraRotateBeforeStart;

    }


    private void CameraMovementBeforeStart()
    {
        _mainCamera.transform.position = Vector3.Lerp(_mainCamera.transform.position, _cameraReferanceTransform.position, CameraMovemenSpeed * Time.deltaTime);

    }
    private void CameraRotateBeforeStart()
    {

        _mainCamera.transform.rotation = Quaternion.Lerp(_mainCamera.transform.rotation, _cameraReferanceTransform.rotation, CameraRotateSpeed * Time.deltaTime);


    }

    
    private void ShakeCamera()
    {
        
      //  _mainCamera.

    }
    


}
