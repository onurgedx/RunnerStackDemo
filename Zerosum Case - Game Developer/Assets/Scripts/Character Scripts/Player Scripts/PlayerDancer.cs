using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDancer : MonoBehaviour
{
    public Action OnDanceStart;

    private void Start()
    {

        LevelManager.Instance.OnLevelFinish += Dance;
        
    }

    private void Dance()
    {
        OnDanceStart?.Invoke();
    }
}
