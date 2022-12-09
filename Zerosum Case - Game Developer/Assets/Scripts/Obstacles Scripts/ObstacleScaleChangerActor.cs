using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScaleChangerActor : MonoBehaviour
{


    private Transform _transform;

    private Vector3 _recordedScale;
    private Vector3 _tempScale;

    public float ScaleChangeSpeed=4f;
    public float MaxAdditionalAspectOfScale = 0.5f;

    private void Start()
    {
        _transform = transform;
        _recordedScale = _transform.localScale;
        _tempScale = _recordedScale;

    }

    private void Update()
    {
        PingPongScale();
    }

    private void PingPongScale()
    {

        _tempScale = _recordedScale + Mathf.PingPong(Time.time*ScaleChangeSpeed, 1) * _recordedScale*MaxAdditionalAspectOfScale;

        _transform.localScale = _tempScale;
           

        
    }



}
