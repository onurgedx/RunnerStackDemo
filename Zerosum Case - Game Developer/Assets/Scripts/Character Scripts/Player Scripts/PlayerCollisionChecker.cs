using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionChecker : MonoBehaviour
{

    
    public Action<int> OnGainCollectable;
    public Action<int> OnCrushAObstacle;
    private IPlayer _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<IPlayer>();
        
    }

   

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.TryGetComponent(out ICollectable collectable))
        {
            collectable.Collect(_player);
            OnGainCollectable?.Invoke(collectable.StackValue());
        }
        if(other.gameObject.TryGetComponent(out IObstacle obstacle))
        {
            obstacle.BeCrushed();
            OnCrushAObstacle?.Invoke(obstacle.GetDamageAmountAsStackCount());
            CameraManager.Instance.ShakeCamera();
        }
        
    }
}
