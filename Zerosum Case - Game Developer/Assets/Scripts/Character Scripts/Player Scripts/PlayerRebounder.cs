using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRebounder : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerCollisionChecker _playerCollisionChecker;


    // Start is called before the first frame update
    void Start()
    {
        _playerCollisionChecker.OnCrushAObstacle += Rebound;

    }
    #region Rebound 
    private void Rebound(int a)
    {

        StartCoroutine(ReboundIEnumerator());


    }

    private IEnumerator ReboundIEnumerator()
    {

        _playerMovement.AspectOfSpeed = _playerData.Data.ReboundAmount;
        float timeCounter = 0;

        while (timeCounter < 1)
        {
            timeCounter = Mathf.Clamp01(timeCounter + Time.deltaTime);
            _playerMovement.AspectOfSpeed = Mathf.Lerp(_playerData.Data.ReboundAmount, 1, timeCounter);

            yield return null;

        }

    }
    #endregion


}
