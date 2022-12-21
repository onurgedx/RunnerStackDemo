using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCrushEffector : MonoBehaviour
{
    [SerializeField] private ObstacleBase _obstacleBase;
    // Start is called before the first frame update
    void Start()
    {
        _obstacleBase.OnBeCrushed += RunCrushEffect;
        
    }

    private void RunCrushEffect()
    {
        ParticleSystem particleSystem = ObjectPoolManager.Instance.ObstacleShurikenCrushFxPool.GetPoolMember();
        particleSystem.transform.position = transform.position;
        particleSystem.Play();
        particleSystem.transform.DeactiveTransformAfterxTimeSecond(3);

    }
   


}
