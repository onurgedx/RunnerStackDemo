using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollectable : MonoBehaviour , ICollectable
{

    [SerializeField] private CollectableDataScriptable _collectableData;

    public Action<IPlayer> OnBeCollected;

    

    public void Collect(IPlayer player)
    {
        OnBeCollected?.Invoke(player);

    }

    public int GetStackValue()
    {
        return _collectableData.StackCost;
    }

    public int GetValueAsGold()
    {
        return _collectableData.ValueAsGoldCoin;

    }

    public int GetStackCostAsGoldForFinalCalculating()
    {
        if (_collectableData.CollectableType == CollectablesEnum.CoinGold)
        {
            return 0;
        }
        return _collectableData.ValueAsGoldCoin;
    }

}
