using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(3)]
public class PlayerStack : MonoBehaviour
{

    [SerializeField] private PlayerCollisionChecker _playerCollisionChecker;

    public Action<int> OnMaxStackCountChange;

    public Action<int> OnStackCountChange;

    public Action OnStackFull;

    public Action OnStackLose;

    private int _stackCount;

    private bool _canStackIncrease = true;
    public int StackCount
    {
        get
        {

            return _stackCount;

        }
        set
        {
            if (_stackCount != value)
            {

                _stackCount = Mathf.Clamp(value, 0, MaxStackCount);
                OnStackCountChange?.Invoke(_stackCount);

                if (_stackCount == _maxStackCount)
                {
                    OnStackFull?.Invoke();
                   
                }



            }

        }
    }


    private int _maxStackCount;

    public int MaxStackCount
    {
        get
        {
            return _maxStackCount;
        }
        set
        {
            if (value != _maxStackCount)
            {

                _maxStackCount = value;

                OnMaxStackCountChange?.Invoke(_maxStackCount);

                PlayerPrefs.SetInt(GlobalStrings.MaxStackCount, _maxStackCount);

            }
        }
    }
    void Start()
    {
        
        ResetStackCountZero();
        LevelManager.Instance.OnLevelLoad += ResetStackCountZero;
        _playerCollisionChecker.OnGainCollectable += IncreaseStackCount;
        _playerCollisionChecker.OnCrushAObstacle += DecreaseStackCount;
        _playerCollisionChecker.CanCollect += CanStackable;

        MaxStackCount = 0;
        MaxStackCount = PlayerPrefs.GetInt(GlobalStrings.MaxStackCount, GlobalNumbers.DefaultMaxStackCount);
        CanvasManager.Instance.OnUpgrade += IncreaseMaxStackCount;
        
        OnStackFull += SetLayerIgnoreDiamonts;
        OnStackLose += SetLayerPlayer;
        LevelManager.Instance.OnLevelLoad += SetLayerPlayer;

    }

    private bool CanStackable()
    {
        return _canStackIncrease;

    }


    private void ResetStackCountZero()
    {
        StackCount = 0;

    }

    private void IncreaseStackCount(int increaseAmount = 1)
    {
        if (_canStackIncrease)
        {

            StackCount += increaseAmount;
        }


    }
    private void DecreaseStackCount(int decreaseAmount = 1)
    {

        OnStackLose?.Invoke();
        _canStackIncrease = true;


        StackCount = 0;

    }
    private void SetLayerIgnoreDiamonts()
    {
        gameObject.layer = 8;
        
    }
    private void SetLayerPlayer()
    {
        gameObject.layer = 6;
    }

   


    private void IncreaseMaxStackCount()
    {

        MaxStackCount++;

    }

}
