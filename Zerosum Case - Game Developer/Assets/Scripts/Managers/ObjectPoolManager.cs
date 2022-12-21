using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
{
    


    [Serializable]
    public class Pool<T> where T : Component
    {
        public T PoolPrefab;

        public List<T> PoolList = new List<T>();

        public T GetPoolMember()
        {

            for (int i = 0; i < PoolList.Count; i++)
            {
                if (!PoolList[i].gameObject.activeInHierarchy)
                {

                    PoolList[i].gameObject.SetActive(true);
                    return PoolList[i];

                }

            }
            GameObject newPoolMembersGameObject = Instantiate(PoolPrefab.gameObject);
            T newPoolMember = newPoolMembersGameObject.GetComponent<T>();
            PoolList.Add(newPoolMember);
            newPoolMembersGameObject.SetActive(true);
            return newPoolMember;

        }

    }

    public Pool<ParticleSystem> CrushParticlePool;
    public Pool<ParticleSystem> GainParticlePool;
    public Pool<ParticleSystem> ObstacleShurikenCrushFxPool;
    








}
