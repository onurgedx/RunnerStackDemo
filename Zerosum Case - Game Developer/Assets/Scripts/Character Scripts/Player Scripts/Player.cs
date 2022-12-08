using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        
    }
    public Transform GetTransform()
    {
        return _transform;
    }
}
