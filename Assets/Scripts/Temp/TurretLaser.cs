using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TurretLaser : TowerManager
{
    private Hostile _target;
    private Health _targetHealth;

    public float _shootTimer = 1.0f;
    public bool _attack = false;

    public override bool CanAttack()
    {
        _target = _rangeChecker.GetHostileInRange();
        return _target != null;
    }

    public override void Attack()
    {
        _shootTimer -= Time.deltaTime;

        if (_shootTimer <= 0.0f)
        {
            _attack = true;
            if (_attack == true)
            {
                _targetHealth.TakeDamage(_damage);
                Debug.Log(_damage);
                StartCoroutine(LookAtTarget());
            }
        }
        else
        {
            _attack = false;
        }
    }

    IEnumerator LookAtTarget()
    {
        Vector3 _targetLocation = new Vector3(_target.transform.position.x, _target.transform.position.y, _target.transform.position.z);
        yield return _targetLocation;
        transform.LookAt(_targetLocation);
    }
}