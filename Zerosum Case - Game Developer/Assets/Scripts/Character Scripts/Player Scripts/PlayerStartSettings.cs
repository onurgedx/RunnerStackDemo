using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartSettings : MonoBehaviour
{
    private Vector3 _recordedStartPosition;
    // Start is called before the first frame update
    void Start()
    {
        RecordStartPosition();
        LevelManager.Instance.OnLevelLoad += ResetPosition;
        
    }

    
    private void RecordStartPosition()
    {
        _recordedStartPosition = transform.position;

    }
    private void ResetPosition()
    {
        transform.position = _recordedStartPosition;

    }
}
