using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaterToCamera : MonoBehaviour
{

    private Transform _cameraTransform;

    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _cameraTransform = Camera.main.transform;
        _transform = transform;
    }


    private void LateUpdate()
    {

        LookAtCamera();
        
    }

    private void LookAtCamera()
    {

        _transform.rotation = Quaternion.LookRotation(_cameraTransform.position - _transform.position);


    }

}
