using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : BaseTower
{
    public GameObject _hostileInRange;

    [SerializeField] private GameObject bulletPrefab;
    public float _shootTimer = 1.0f;
    protected float shootTimer;

    private void Start()
    {
        shootTimer = _shootTimer;
    }

    public override void Update()
    {
        base.Update();
        _hostileInRange = gameObject.GetComponentInParent<Detection>().RangeChecker();
        TurretFire();
    }

    public LaserTurret TurretFire()
    {
        if (_detected == false)
        {
            return null;
        }
        else
        {
            if (_hostileInRange != null)
            {
                //Debug.Log(shootTimer);
                _shootTimer -= Time.deltaTime;
                transform.LookAt(_hostileInRange.transform.position);
                if (_shootTimer <= 0.0f)
                {
                    GameObject abullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                    abullet.transform.LookAt(_hostileInRange.transform);
                    abullet.GetComponent<Bullet>()._target = _hostileInRange;
                    _shootTimer = shootTimer;
                }
            }
            else
            {
                _hostileInRange = gameObject.GetComponentInParent<Detection>().RangeChecker();
            }

            return null;
        }
    }
}
