using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpinerType001 : MonoBehaviour
{
    [SerializeField] private Transform _transformThatWillBeSpin;


    public Action SpinEvent;

    public float SpinSpeed=270;
    
    // Start is called before the first frame update
    void Start()
    {
        ActivateSpining();

    }

    // Update is called once per frame
    void Update()
    {

        SpinEvent?.Invoke();


    }

    private void ActivateSpining()
    {
        SpinEvent = SpinObstacle;

    }
    private void DeactivateSpining()
    {
        SpinEvent = null;
    }

    private void SpinObstacle()
    {

        _transformThatWillBeSpin.Rotate(Vector3.up * SpinSpeed * Time.deltaTime, Space.Self);

    }

}
