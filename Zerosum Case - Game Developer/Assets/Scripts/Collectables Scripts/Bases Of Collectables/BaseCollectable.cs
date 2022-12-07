using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollectable : MonoBehaviour , ICollectable
{

    [SerializeField] private CollectableDataScriptable _collectableData;

    public Action OnBeCollected;

    public void Collect()
    {
        OnBeCollected?.Invoke();
        gameObject.SetActive(false);
    }

    public int StackValue()
    {
        return _collectableData.StackCost;
    }

  
}
