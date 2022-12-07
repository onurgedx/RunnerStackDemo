using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerCollectBounceEffector : MonoBehaviour
{

    public float BounceSpeed=5.3f;
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

        StartCoroutine(BounceIEnumerator());
    }

    private IEnumerator BounceIEnumerator()
    {
        Vector3 recordedFirstAvatarScale = _childestAvatarModelTransform.localScale;
        
        float timeCounter = 0;
        while (timeCounter <1)
        {
            timeCounter = Mathf.Clamp(timeCounter + Time.deltaTime*BounceSpeed, 0, 1);

            _childestAvatarModelTransform.localScale = recordedFirstAvatarScale * (1 + Mathf.Sin(Mathf.PI * timeCounter)*0.1f);

            yield return null;


        }

    }
}
