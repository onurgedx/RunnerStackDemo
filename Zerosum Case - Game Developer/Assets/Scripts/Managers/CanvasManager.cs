using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoSingleton<CanvasManager>
{

    public Action OnStartMenuActivate;
    public Action OnFinishMenuActivate;
    

    [SerializeField] private GameObject _startMenu, _inGameUI, _finishMenu;



    [SerializeField] private Text _levelNumberText;
    [SerializeField] private Text _currencyAmountText;

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
        _upgradeButton.onClick.AddListener(UpdateCurrencyAmountText);// i did this to show you i know that way.

        UpdateCurrencyAmountText();
        SetUpgradeButtonInteractable();
        LevelManager.Instance.OnLevelStart += ActivateInGameIU;
        LevelManager.Instance.OnLevelFinish += ActivateFinishMenu;
        LevelManager.Instance.OnLevelLoad += ActivateStartMenu;
        LevelManager.Instance.OnLevelNumberChange += UpdateLevelNumberText;
        CurrencyManager.Instance.OnCurrencyAmountChange += SetUpgradeButtonInteractable;
    }
    private void UpdateLevelNumberText()
    {
        _levelNumberText.text = GlobalStrings.Level + " " + LevelManager.Instance.LevelNumber.ToString();

    }

    public void UpdateCurrencyAmountText()
    {
        _currencyAmountText.text = CurrencyManager.Instance.CurrencyAmount.ToString();
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
