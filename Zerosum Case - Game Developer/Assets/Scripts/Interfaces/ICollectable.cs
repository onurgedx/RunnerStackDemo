using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
   
    public void Collect(IPlayer player);
    public int GetStackValue();

    public int GetStackCostAsGoldForFinalCalculating();
}
