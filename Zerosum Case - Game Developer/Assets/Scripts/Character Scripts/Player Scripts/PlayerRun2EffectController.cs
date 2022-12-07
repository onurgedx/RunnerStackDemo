using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun2EffectController : MonoBehaviour
{

    [SerializeField] private List<GameObject> _trailList = new List<GameObject>();
    [SerializeField] private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement.OnRun1MovementStart += DeactivateTrails;
        _playerMovement.OnRun2MovementStart += ActivateTrails;
        _playerMovement.OnMovementEnd += DeactivateTrails;
    }
    private void ActivateTrails()
    {
        for (int i = 0; i < _trailList.Count; i++)
        {
            _trailList[i].SetActive(true);

        }
    }

    private void DeactivateTrails()
    {
        for (int i = 0; i < _trailList.Count; i++)
        {
            _trailList[i].SetActive(false);

        }

    }

}
