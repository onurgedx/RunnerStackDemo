using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinisher : MonoBehaviour
{

    [SerializeField] private Renderer _myRenderer;
    

    private void Start()
    {
        _myRenderer.enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.TryGetComponent(out IPlayer player))
        {

            FinishLevel();
        }

    }

    private void FinishLevel()
    {
        LevelManager.Instance.FinishLevel();
    }



}
