using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class GoldBeGainedActor : BaseBeGainedActor, IBeGained
{
   
    private Transform _transform;
    

    // Start is called before the first frame update
    void Start()
    {

        _baseCollectable.OnBeCollected += MoveToGoldIcon;
        _baseCollectable.OnBeCollected += RunBeGainedEffect;

        _transform = transform;


    }
    private void RunBeGainedEffect(IPlayer player)
    {

       _transform.DOScale(0, Durations.BeGainedDuration).SetLink(gameObject);


    }
    private void MoveToGoldIcon(IPlayer player)
    {
        StartCoroutine(MoveToGoldIconIEnumerator());
        IEnumerator MoveToGoldIconIEnumerator()
        {


            float timeCounter = 0;
            Transform destinationTransform = CanvasManager.Instance.CurrencyAmountInGameTransform;
            float timeAspectForLerp = 1 / Durations.BeGainedDuration;

            while (timeCounter < Durations.BeGainedDuration)
            {

                timeCounter += Time.deltaTime;
                _transform.position = Vector3.Lerp(_transform.position, destinationTransform.position, timeAspectForLerp * timeCounter);

                yield return null;

            }

            OnArrived();
            
            gameObject.SetActive(false);
        }
    }

   
    public void OnArrived()
    {
        OnArrivedEvents?.Invoke(_baseCollectable.GetValueAsGold());
    }
}