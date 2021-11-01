using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTower : BaseTower
{
    public Hostile[] _allHostilesInRange;

    public float _originalSpeed;

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
            if (_allHostilesInRange != null)
            {
                foreach (var hostile in _allHostilesInRange)
                {
                    //StartCoroutine(SlowHostile(hostile));
                    hostile.SlowEnemy();
                }
            }
            else
            {
                _allHostilesInRange = gameObject.GetComponent<Detection>().AllInRangeChecker();
            }
        }
        return null;
    }
}
