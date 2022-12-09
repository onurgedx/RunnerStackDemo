using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollectable : BaseCollectable
{

    public override int GetStackCostAsGoldForFinalCalculating()
    {
        return 0;
    }
}
