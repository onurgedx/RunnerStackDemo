using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoSingleton<CanvasManager>
{



    public Transform CurrencyAmountInGameTransform;


    public Action OnStartMenuActivate;
    public Action OnFinishMenuActivate;

    public Action OnUpgrade;

    [SerializeField] private GameObject _startMenu, _inGameUI, _finishMenu;



    [SerializeField] private List<Text> _levelNumberTextList;
    [SerializeField] private List<Text> _currencyAmountTextList;

    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Button _playButtton;




    private void ActivateStartMenu()
    {
        OnStartMenuActivate?.Invoke();
        _startMenu.SetActive(true);
        _inGameUI.SetActive(false);
        _finishMenu.SetActive(false);

    }
   
    private void ActivateInGameIU()
    {

        _inGameUI.SetActive(true);
        _finishMenu.SetActive(false);
        _startMenu.SetActive(false);

    }
    private void ActivateFinishMenu()
    {
        OnFinishMenuActivate?.Invoke();
        _finishMenu.SetActive(true);
        _inGameUI.SetActive(false);
        _startMenu.SetActive(false);
    }

    private void Start()
    {
        
        _upgradeButton.onClick.AddListener(UpgradeButtonPressed);// i did this to show you i know that way.
        UpdateCurrencyAmountText();
        SetUpgradeButtonInteractable();
        LevelManager.Instance.OnLevelStart += ActivateInGameIU;
        LevelManager.Instance.OnLevelFinish += ActivateFinishMenu;
        LevelManager.Instance.OnLevelLoad += ActivateStartMenu;
        LevelManager.Instance.OnLevelNumberChange += UpdateLevelNumberText;
        CurrencyManager.Instance.OnCurrencyAmountChange += SetUpgradeButtonInteractable;
        CurrencyManager.Instance.OnCurrencyAmountChange += UpdateCurrencyAmountText;
    }
    private void UpdateLevelNumberText()
    {
        string levelNumberText =GlobalStrings.Level + " " + LevelManager.Instance.LevelNumber.ToString();
        for (int i = 0; i < _levelNumberTextList.Count; i++)
        {
            _levelNumberTextList[i].text = levelNumberText;

        }


    }
    private void UpgradeButtonPressed()
    {
        OnUpgrade?.Invoke();
    }
    public void UpdateCurrencyAmountText()
    {
        string currencyAmountStr = CurrencyManager.Instance.CurrencyAmount.ToString();
        for (int i = 0; i < _currencyAmountTextList.Count; i++)
        {

            _currencyAmountTextList[i].text = currencyAmountStr;
        }
    }
    private void SetUpgradeButtonInteractable()
    {

        if (CurrencyManager.Instance.CurrencyAmount >= CurrencyManager.Instance.UpgradeCost)
        {
            _upgradeButton.interactable = true;

        }
        else
        {
            _upgradeButton.interactable = false;
        }


    }

}
