using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    public Action OnMenuActivated;
    public Action OnMenuDeactivated;
    public Action OnLevelStart;
    public Action OnLevelFinish;



    
}
