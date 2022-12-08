using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrushObstacleLoseDiamondsEffector : MonoBehaviour
{
    [SerializeField] private PlayerCollisionChecker _playerCollisionChecker;
    // Start is called before the first frame update
    void Start()
    {
        _playerCollisionChecker.OnCrushAObstacle += RunCrushFxEffect;


    }

  
       private void RunCrushFxEffect(int a)
    {
        ParticleSystem particleSystem = ObjectPoolManager.Instance.GetCrushFx();
        particleSystem.transform.position = transform.position + Vector3.up;

        particleSystem.Play();
        particleSystem.transform.DeactiveTransformAfterxTimeSecond(1);

    }



}
