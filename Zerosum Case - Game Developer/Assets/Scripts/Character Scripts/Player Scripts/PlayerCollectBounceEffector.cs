using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectBounceEffector : MonoBehaviour
{

    [SerializeField] private PlayerCollisionChecker _playerCollisionChecker;
    [SerializeField] private Transform _childestAvatarModelTransform;

    // Start is called before the first frame update
    void Start()
    {
        _playerCollisionChecker.OnGainCollectable += Bounce;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Bounce(int stackCost)
    {


    }
}
