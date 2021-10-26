using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected bool _detected;
    public float _shootTimer = 1.0f;
    public GameObject _hostileInRange;

    [SerializeField] protected GameObject bulletPrefab;

    public void Update()
    {
        _detected = gameObject.GetComponentInParent<Detection>()._detection;
        _hostileInRange = gameObject.GetComponentInParent<Detection>().RangeChecker();
        TurretFire();
    }
    public virtual Tower TurretFire()
    {
        if (_detected == false)
        {
            return null;
        }
        else
        {
            if (_hostileInRange != null)
            {
                //float shootTimer = _shootTimer;
                _shootTimer -= Time.deltaTime;
                transform.LookAt(_hostileInRange.transform.position);
                if (_shootTimer <= 0.0f)
                {
                    GameObject abullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                    abullet.transform.LookAt(_hostileInRange.transform);
                    _shootTimer = 0.5f;
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