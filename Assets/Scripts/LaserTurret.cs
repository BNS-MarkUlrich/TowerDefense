using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    private bool _detected;
    public float _shootTimer = 1.0f;
    private Health _hostileInRange;

    private Hostile _hostileLocation;

    [SerializeField] private float _damage;

    private void Update()
    {
        _detected = gameObject.GetComponent<Detection>()._detection;
        _hostileInRange = gameObject.GetComponent<Detection>().RangeChecker();
        TurretFire();
    }

    private LaserTurret TurretFire()
    {
        if (_detected == false)
        {
            return null;
        }
        else
        {
            if (_hostileInRange != null)
            {
                _shootTimer -= Time.deltaTime;
                transform.LookAt(_hostileInRange.transform.position);
                if (_shootTimer <= 0.0f)
                {
                    //Debug.Log(_hostileInRange._currentHealth);
                    _hostileInRange.TakeDamage(_damage);
                    _shootTimer = 1.0f;
                }
            }
            
            return null;
        }
    }
}
