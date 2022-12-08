using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class BaseBeGainedActor : MonoBehaviour,IBeGained
{
    public Action OnArrivedEvents;
    [SerializeField] private BaseCollectable _baseCollectable;

    // Start is called before the first frame update
    void Start()
    {
        _baseCollectable.OnBeCollected += RunBeGainedEffect;
        _baseCollectable.OnBeCollected += MoveToPlayer;
    }

    private void RunBeGainedEffect(IPlayer player)
    {


        transform.DOScale(0, Durations.BeGainedDuration).SetEase(Ease.InBack).OnComplete(() => gameObject.SetActive(false)).SetLink(gameObject);


    }

    private void MoveToPlayer(IPlayer player)
    {
        StartCoroutine(MoveToPlayerIEnumerator());

        IEnumerator MoveToPlayerIEnumerator()
        {
            float timeCounter = 0;
            float timeAspectForLerp = 1 / Durations.BeGainedDuration;
            Vector3 recordedFirstPosition = transform.position;

            while (timeCounter < Durations.BeGainedDuration)
            {
                timeCounter += Time.deltaTime;
                
                transform.position = Vector3.Lerp(recordedFirstPosition,player.GetTransform().position+Vector3.up,timeCounter*timeAspectForLerp);

                yield return null;

            }


            OnArrived();

        }
    }

    public void OnArrived()
    {
        OnArrivedEvents?.Invoke();
    }

    
}
