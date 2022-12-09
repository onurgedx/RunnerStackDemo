using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollectable : BaseCollectable
{
    public override int GetStackCostAsGoldForFinalCalculating()
    {

        return _collectableData.ValueAsGoldCoin;
    }
}
