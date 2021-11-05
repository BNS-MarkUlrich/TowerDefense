using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTower : LaserTurret
{
    public override void Start()
    {
        shootTimer = _shootTimer;
    }

    public override void Update()
    {
        _detected = gameObject.GetComponentInParent<Detection>()._detection;
        _hostileInRange = gameObject.GetComponentInParent<Detection>().RangeChecker();
        TurretFire();
    }
}
