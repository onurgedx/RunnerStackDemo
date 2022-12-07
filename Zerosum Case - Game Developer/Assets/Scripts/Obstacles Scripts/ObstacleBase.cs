using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBase : MonoBehaviour, IObstacle
{
    public event Action OnBeCrushed;

    [SerializeField] private ObstacleDataScriptable _obstacleData;

  

    public virtual void BeCrushed()
    {
        OnBeCrushed?.Invoke();
        gameObject.SetActive(false);


    }

    public virtual int GetDamageAmountAsStackCount()
    {
        return _obstacleData.StackCost;
    }
}
