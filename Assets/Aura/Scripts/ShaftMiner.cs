using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    protected override void CollectGold()
    {
        FlipMiner(-1);
        MoveMiner(depositLocation.position);
        SwitchGoal();
    }

    protected override void DepositGold()
    {
        FlipMiner(1);
        MoveMiner(collectingLocation.position);
        SwitchGoal();
    }
}
