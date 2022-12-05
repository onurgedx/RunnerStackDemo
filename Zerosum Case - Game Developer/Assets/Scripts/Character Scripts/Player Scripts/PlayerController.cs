using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private Transform _playerLookHereZRerefanceTransform;
    [SerializeField] private Transform _playerAvatarModelLooksHereTransform;

    [SerializeField] private List<Transform> _clampXPositionTransforms = new List<Transform>();


    private void Start()
    {

        InputManager.Instance.OnInput += SetPositionPlayerLooksTransform;

    }


    private void SetPositionPlayerLooksTransform(Vector3 inputDirection)
    {
        Vector3 positionOfPlayerLooks = _playerAvatarModelLooksHereTransform.position;

        positionOfPlayerLooks.z = _playerLookHereZRerefanceTransform.position.z;

        positionOfPlayerLooks.x = Mathf.Clamp(positionOfPlayerLooks.x+inputDirection.x, _clampXPositionTransforms[0].position.x,_clampXPositionTransforms[1].position.x);
        _playerAvatarModelLooksHereTransform.position = positionOfPlayerLooks;

    }


    





   
}
