using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : MonoBehaviour
{

    [SerializeField] private PlayerCollisionChecker _playerCollisionChecker;

    public Action<int> OnMaxStackCountChange;

    public Action<int> OnStackCountChange;

    public Action OnStackFull;

    public Action OnStackLose;

    private int _stackCount;

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

                _stackCount = Mathf.Clamp( value,0,MaxStackCount);
                OnStackCountChange?.Invoke(_stackCount);
                
                if(_stackCount == _maxStackCount)
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

    private void ResetStackCountZero()
    {
        StackCount = 0;

    }

    private void IncreaseStackCount(int increaseAmount = 1)
    {
        StackCount += increaseAmount;


    }
    private void DecreaseStackCount(int decreaseAmount=1)
    {
        if(StackCount == MaxStackCount)
        { } 
            OnStackLose?.Invoke();
         
        

        StackCount = 0;

    }

    // Start is called before the first frame update
    void Start()
    {
        ResetStackCountZero();
        LevelManager.Instance.OnLevelLoad += ResetStackCountZero;
        _playerCollisionChecker.OnGainCollectable += IncreaseStackCount;
        _playerCollisionChecker.OnCrushAObstacle += DecreaseStackCount;

        MaxStackCount = 0;
        MaxStackCount = PlayerPrefs.GetInt(GlobalStrings.MaxStackCount, GlobalNumbers.DefaultMaxStackCount);
        CanvasManager.Instance.OnUpgrade += IncreaseMaxStackCount;
        
    }

    private void IncreaseMaxStackCount()
    {
        
        MaxStackCount++;

    }

}
