using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : MonoBehaviour
{


    [SerializeField] private PlayerCollisionChecker _playerCollisionChecker;


    public Action<int> OnMaxStackCountChange;
    public Action<int> OnStackCountChange;

    private int _stackCount;


    public int StackCount
    {
        get
        {

            return _stackCount;

        }
        set
        {
            if(_stackCount!= value)
            {

            _stackCount = value;
            OnStackCountChange?.Invoke(_stackCount);
            }

        }
    }


    private int _maxStackCount;

    public int MaxStackCount
    {
        get { return _maxStackCount; }
        set
        {
            if (value != _maxStackCount)
            {

                _maxStackCount = value;
                OnMaxStackCountChange?.Invoke(_maxStackCount);

            }
        }
    }

    private void ResetStackCountZero()
    {
        StackCount = 0;

    }

    private void IncreaseStackCount( int increaseAmount =1)
    {
        StackCount += increaseAmount; 


    }

    // Start is called before the first frame update
    void Start()
    {

        LevelManager.Instance.OnLevelLoad += ResetStackCountZero;
        _playerCollisionChecker.OnGainCollectable += IncreaseStackCount;

    }

}
