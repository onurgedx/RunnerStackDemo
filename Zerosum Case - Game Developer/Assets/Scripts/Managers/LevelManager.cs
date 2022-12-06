using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{



    [SerializeField] private List<GameObject> _levels;

    private GameObject _currentLevel;
    

    
    public Action OnLevelStart;
    public Action OnLevelFinish;
    public Action OnLevelLoad;

    private int _levelNumber;

    public Action OnLevelNumberChange;

    public int LevelNumber
    {
        get
        {
            return _levelNumber;

        }
        set
        {
            if(_levelNumber!=value)
            {
                _levelNumber = value;
                PlayerPrefs.SetInt(GlobalStrings.LevelNumber, _levelNumber);
                OnLevelNumberChange?.Invoke();
            }
            
        }
    }
    

    private void Start()
    {
        LevelNumber = PlayerPrefs.GetInt(GlobalStrings.LevelNumber, 1);
        OnLevelFinish += LevelUp;
        OnLevelLoad += LoadNextLevel;
        LoadNextLevel();
        
    }

    private void LevelUp()
    {
        LevelNumber++;

    }


    public void StartLevel()
    {
        OnLevelStart?.Invoke();
    }
    public void FinishLevel()
    {
        OnLevelFinish?.Invoke();
    }


    public void NextLevel()
    {

        OnLevelLoad?.Invoke();

    }


    private void LoadNextLevel()
    {

        Destroy(_currentLevel);
        _currentLevel = Instantiate(_levels[(LevelNumber - 1) % _levels.Count]);
        _currentLevel.transform.position = Vector3.zero;
        _currentLevel.SetActive(true);

    }

}
