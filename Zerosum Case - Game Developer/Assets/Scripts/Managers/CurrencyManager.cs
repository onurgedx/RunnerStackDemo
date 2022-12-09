using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoSingleton<CurrencyManager>
{

    public Action OnCurrencyAmountChange;
    public Action OnUpgradeCostChange;
    
  private int _currencyAmount;
    private int _upgradeCost;

    private void Awake()
    {
        CurrencyAmount = PlayerPrefs.GetInt(GlobalStrings.CurrencyAmount, 50);
        UpgradeCost = PlayerPrefs.GetInt(GlobalStrings.UpgradeCost, 50);
    }

    public void DecreaseCurrencyAmount()
    {
        
        CurrencyAmount = Mathf.Clamp(CurrencyAmount - UpgradeCost, 0, 1000000);


    }
    public int UpgradeCost
    {
        get { return _upgradeCost; }
        set
        {
            if(value != _upgradeCost)
            {
                _upgradeCost = value;
                PlayerPrefs.SetInt(GlobalStrings.UpgradeCost, _upgradeCost);
                
            }

        }
    }
    
  
    public int CurrencyAmount
    {
        get { return _currencyAmount; }
        set
        {
            if(value!= _currencyAmount)
            {
                
                   _currencyAmount = value;
                PlayerPrefs.SetInt(GlobalStrings.CurrencyAmount, _currencyAmount);
                OnCurrencyAmountChange?.Invoke();
            }

        }
    }

}
