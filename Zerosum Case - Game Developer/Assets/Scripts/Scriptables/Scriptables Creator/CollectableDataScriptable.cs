using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "CollectableData", menuName = "ScriptablesObject/CollectableData")]
public class CollectableDataScriptable : ScriptableObject
{
    public int StackCost = 1;
    public int ValueAsGoldCoin = 50;
}
