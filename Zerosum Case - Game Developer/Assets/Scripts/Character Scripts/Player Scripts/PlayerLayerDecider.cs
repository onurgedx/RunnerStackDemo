using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayerDecider : MonoBehaviour
{

    [SerializeField] private PlayerStack _playerStack;

    private void Start()
    {
        _playerStack.OnStackFull += SetLayerIgnoreDiamonds;
        _playerStack.OnStackLose += SetLayerPlayer;
        LevelManager.Instance.OnLevelLoad += SetLayerPlayer;
    }

    private void SetLayerIgnoreDiamonds()
    {
        gameObject.layer = 8;

    }
    private void SetLayerPlayer()
    {
        gameObject.layer = 6;
    }

}
