using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Hostile
{
    [SerializeField] private float _thiefTimer = 0;
    [SerializeField] private float _drainTimer = 1;
    [SerializeField] private float _continuousDrainer;
    public override void Update()
    {
        base.Update();
        _thiefTimer += Time.deltaTime; // start timer
        if (_thiefTimer >= _drainTimer) // drain every x seconds
        {
            _pointSystem.RemovePoints(_continuousDrainer); // drain
            _thiefTimer = 0; // reset timer
        }
    }
}
