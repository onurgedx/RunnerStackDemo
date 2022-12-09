using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackToGoldTransformer : MonoBehaviour
{

    private int _stacksTotalValue = 0;
    [SerializeField] private PlayerCollisionChecker _playerCollisionChecker;

    private void Start()
    {
        LevelManager.Instance.OnLevelFinish += TransformToGold;
        _playerCollisionChecker.OnGainCollectable += IncreaseValue;
        _playerCollisionChecker.OnCrushAObstacle += ResetValue;
    }

    private void TransformToGold()
    {

        CurrencyManager.Instance.CurrencyAmount += _stacksTotalValue;
        ResetValue();
    }


    private void IncreaseValue(int value)
    {
        _stacksTotalValue += value;
    }

    private void ResetValue(int value)
    {
        _stacksTotalValue = 0;
    }
    private void ResetValue()
    {
        _stacksTotalValue = 0;
    }

}
