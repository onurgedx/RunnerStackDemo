using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleXAxisMovement : MonoBehaviour
{


    public float LenghtOfXAxis = 4;

    [SerializeField] private ObstacleDataScriptable _obstacleData;
    private Transform _transform;
    private Vector3 _tempPosition;
    private Vector3 _recordedPosition;

    public Action MoveOnXAxesEvent;


    private float _speed;


    private void Start()
    {
        _transform = transform;

        MoveOnXAxesEvent += MoveOnXAxis;
        _recordedPosition = _transform.position;
        _tempPosition = _recordedPosition;
        _speed = UnityEngine.Random.Range(_obstacleData.ObstacleXAxisSpeed * .75f, _obstacleData.ObstacleXAxisSpeed * 1.5f);
    }

    private void Update()
    {
        MoveOnXAxesEvent?.Invoke();
    }

    private void MoveOnXAxis()
    {
        
        _tempPosition.x =_recordedPosition.x +Mathf.PingPong(Time.time*_speed, LenghtOfXAxis) -LenghtOfXAxis*0.5f;
        _transform.position = _tempPosition;



    }



}
