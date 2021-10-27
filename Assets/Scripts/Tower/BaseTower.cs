using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    private bool _detected;
    public float _shootTimer = 1.0f;
    private float shootTimer;
    public GameObject _hostileInRange;

    [SerializeField] private GameObject bulletPrefab;

    private void Start()
    {
        shootTimer = _shootTimer;
    }

    public void Update()
    {
        _detected = gameObject.GetComponentInParent<Detection>()._detection;
        _hostileInRange = gameObject.GetComponentInParent<Detection>().RangeChecker();
        TurretFire();
    }

    public virtual BaseTower TurretFire()
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