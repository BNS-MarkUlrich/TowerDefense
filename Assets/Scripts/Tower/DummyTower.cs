using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTower : LaserTurret
{
    void Start()
    {
        shootTimer = _shootTimer;
    }

    private void Update()
    {
        _detected = gameObject.GetComponentInParent<Detection>()._detection;
        _hostileInRange = gameObject.GetComponentInParent<Detection>().RangeChecker();
        TurretFire();
    }
}
