using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "PlayerData" ,menuName ="ScriptablesObject/PlayerData")]
public class PlayerDataScriptable : ScriptableObject
{

    public float MovementSpeedForRun1 = 10f;
    public float MovementSpeedForRun2 = 15;

    public float RotateSpeed = 10f;




}
