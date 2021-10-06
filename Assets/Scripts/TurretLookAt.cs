using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLookAt : MonoBehaviour
{
    private bool _detected;
    private Health _hostileLocation;

    private void Update()
    {
        _detected = gameObject.GetComponentInParent<Detection>()._detection;
        _hostileLocation = gameObject.GetComponentInParent<Detection>().RangeChecker();
        RotateTurret();
    }

    private TurretLookAt RotateTurret()
    {
        if (_detected == false)
        {
            return null;
        }
        else
        {
            if (_hostileLocation != null)
            {
                Vector3 _targetPosition = new Vector3(_hostileLocation.transform.position.x, transform.position.y, _hostileLocation.transform.position.z);
                transform.LookAt(_targetPosition);
            }

            return null;
        }
    }
}
