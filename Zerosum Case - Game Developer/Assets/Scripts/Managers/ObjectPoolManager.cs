using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
{
    [Serializable]
    public class ParticlePool
    {
        public ParticleSystem ParticleSystemPrefab;
        public List<ParticleSystem> PoolList= new List<ParticleSystem>();

    }

    [SerializeField] private ParticlePool _crushParticlePool;
    [SerializeField] private ParticlePool _gainParticlePool;
    [SerializeField] private ParticlePool _obstacleShuriFXPool;


    private ParticleSystem GetFx(ParticlePool particlePool)
    {

        for (int i = 0; i < particlePool.PoolList.Count; i++)
        {
            if (!particlePool.PoolList[i].gameObject.activeInHierarchy)
            {
                particlePool.PoolList[i].gameObject.SetActive(true);
                return particlePool.PoolList[i];
            }

        }

        GameObject particleGo = Instantiate(particlePool.ParticleSystemPrefab.gameObject);

        ParticleSystem particleSystem = particleGo.GetComponent<ParticleSystem>();

        particlePool.PoolList.Add(particleSystem);
        particleGo.SetActive(true);
        return particleSystem;

    }
    public ParticleSystem GetCrushFx()
    {
        return GetFx(_crushParticlePool);
      
    }
    
    public ParticleSystem GetObstacleCrushFx()
    {
        return GetFx(_obstacleShuriFXPool);
    }

    public ParticleSystem GetGainFx()
    {
        return GetFx(_gainParticlePool);
    }

    
}
