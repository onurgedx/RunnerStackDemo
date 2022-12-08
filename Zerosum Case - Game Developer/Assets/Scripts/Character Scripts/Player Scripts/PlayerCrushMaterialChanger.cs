using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrushMaterialChanger : MonoBehaviour
{

    [SerializeField] private PlayerCollisionChecker _playerCollisionCheker;

    [SerializeField] private SkinnedMeshRenderer _meshRenderer;


    [SerializeField] private Material[] _normalMaterialList;
    [SerializeField] private Material[] _crushMaterialList;

     
    // Start is called before the first frame update
    void Start()
    {
        _playerCollisionCheker.OnCrushAObstacle += ChangeMaterialForCrush;

        
    }

    
    private void ChangeMaterialForCrush(int a)
    {
        StartCoroutine(ChangeMaterialIEnumerator());

        IEnumerator ChangeMaterialIEnumerator()
        {
            _meshRenderer.materials = _crushMaterialList;
            yield return new WaitForSeconds(0.2f);
            _meshRenderer.materials = _normalMaterialList;

        }

    }


}
