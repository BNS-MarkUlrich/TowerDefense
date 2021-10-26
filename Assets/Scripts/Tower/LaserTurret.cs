using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    private bool _detected;
    public float _shootTimer = 1.0f;
    public GameObject _hostileInRange;

    [SerializeField] private GameObject bulletPrefab;

    public void Update()
    {
        _detected = gameObject.GetComponentInParent<Detection>()._detection;
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
                _shootTimer -= Time.deltaTime;
                transform.LookAt(_hostileInRange.transform.position);
                if (_shootTimer <= 0.0f)
                {
                    GameObject abullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                    abullet.transform.LookAt(_hostileInRange.transform);
                    abullet.GetComponent<Bullet>()._target = _hostileInRange;
                    _shootTimer = 1.0f;
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