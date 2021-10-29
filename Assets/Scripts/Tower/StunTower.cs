using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTower : BaseTower
{
    public Hostile[] _allHostilesInRange;

    public override void Update()
    {
        base.Update();
        _allHostilesInRange = gameObject.GetComponent<Detection>().AllInRangeChecker();
        TowerStun();
    }

    public StunTower TowerStun()
    {
        if (_detected != false)
        {
            foreach (var hostile in _allHostilesInRange)
            {
                hostile.SlowEnemy();
            }
        }
        return null;
    }
}
