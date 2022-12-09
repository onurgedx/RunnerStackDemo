using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(2)]
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

        _stackBarSlider.gameObject.SetActive(false);


    }


    #region StackBar Slider Updater Methods
    private void UpdateStackBarMaxValue(int maxValue)
    {
        _stackBarSlider.maxValue = maxValue;

    }

    private void UpdateStackBarValue(int valueOfCurrentStack)
    {
        _stackBarSlider.value = valueOfCurrentStack;

    }
    #endregion

    #region Activate/Deactivate Methods
    private void ActivateStackBar()
    {


        _stackBarSlider.gameObject.SetActive(true);


    }
    private void DeactivateStackBar()
    {
        _stackBarSlider.gameObject.SetActive(false);

    }
    #endregion

}
