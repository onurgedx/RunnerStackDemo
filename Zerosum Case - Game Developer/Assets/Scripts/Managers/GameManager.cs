using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{

    // Testing , i will fix here tomorrow
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LevelManager.Instance.OnLevelStart?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            LevelManager.Instance.OnLevelFinish?.Invoke();
        }
    }









}
