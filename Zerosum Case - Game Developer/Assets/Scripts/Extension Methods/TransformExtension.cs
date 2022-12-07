using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public static class TransformExtension
{

    public static void DeactiveTransformAfterxTimeSecond(this Transform _transform,float xTime)
    {

        DOVirtual.DelayedCall(xTime,Deactive);

       void Deactive()
        {
            _transform.gameObject.SetActive(false);

        }
    }


}
