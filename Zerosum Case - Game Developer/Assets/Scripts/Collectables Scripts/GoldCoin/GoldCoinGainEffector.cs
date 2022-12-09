using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinGainEffector : MonoBehaviour
{
    [SerializeField] private BaseCollectable _baseCollectable;


    // Start is called before the first frame update
    void Start()
    {
        _baseCollectable.OnBeCollected +=RunBeGainedCoinEffect;
        
    }



    private void RunBeGainedCoinEffect(IPlayer player)
    {

        ParticleSystem particle = ObjectPoolManager.Instance.GetGainFx();
        particle.transform.position = transform.position;
        particle.Play();
        particle.transform.DeactiveTransformAfterxTimeSecond(1);

    }
}
