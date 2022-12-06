using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUIStackBarController : MonoBehaviour
{

    

    [SerializeField] private Slider _stackBarSlider;
    [SerializeField] private PlayerStack _playerStack;


    // Start is called before the first frame update
    void Start()
    {

        LevelManager.Instance.OnLevelStart += ActivateStackBar;
        LevelManager.Instance.OnLevelFinish += DeactivateStackBar;

        _playerStack.OnMaxStackCountChange += UpdateStackBarMaxValue;
        _playerStack.OnStackCountChange += UpdateStackBarValue;


    }

  
    private void UpdateStackBarMaxValue(int maxValue)
    {
        _stackBarSlider.maxValue = maxValue;

    }

    private void UpdateStackBarValue(int valueOfCurrentStack)
    {
        _stackBarSlider.value = valueOfCurrentStack;

    }
    private void ActivateStackBar()
    {


        _stackBarSlider.gameObject.SetActive(true);


    }
    private void DeactivateStackBar()
    {
        _stackBarSlider.gameObject.SetActive(false);

    }

}
