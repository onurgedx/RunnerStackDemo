using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyIncreaser : MonoBehaviour
{
    [SerializeField] private BaseBeGainedActor _baseBeGainedActor;


    private void Start()
    {
        _baseBeGainedActor.OnArrivedEvents += IncreaseCurrency;
        
    }
    private void IncreaseCurrency(int valueAsGold)
    {
        CurrencyManager.Instance.CurrencyAmount += valueAsGold;
    }

   
}
