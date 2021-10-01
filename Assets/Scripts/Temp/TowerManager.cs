using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public RangeChecker _rangeChecker;

    protected bool _isShooting;
    [SerializeField] protected float _damage;

    public void Awake()
    {
        _rangeChecker = GetComponent<RangeChecker>();
    }

    public virtual bool CanAttack()
    {
        return false;
    }

    public virtual void Attack()
    {

    }
}