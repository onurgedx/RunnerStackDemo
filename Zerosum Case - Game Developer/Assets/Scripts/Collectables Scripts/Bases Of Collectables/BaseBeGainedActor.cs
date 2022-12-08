using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBeGainedActor : MonoBehaviour
{
    public Action<int> OnArrivedEvents;
    [SerializeField] protected BaseCollectable _baseCollectable;
}
