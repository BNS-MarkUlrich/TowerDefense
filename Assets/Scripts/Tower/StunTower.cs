using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunTower : MonoBehaviour
{
    public Hostile[] _allHostilesInRange;
    private bool _detected;

    private void Update()
    {
        _detected = gameObject.GetComponentInParent<Detection>()._detection;
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
