using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    //[SerializeField] private GameObject laserPrefab;

    public float _speed;
    public GameObject _hostile;

    public float _shootTimer = 1;
    public float _currentTimer;

    //public float _shootTimer = 0.1f;
    [SerializeField] private LayerMask _layer;

    private void Start()
    {
        _currentTimer = _shootTimer;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TurretPlayer();
        }

        _shootTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && _shootTimer < 0)
        {
            TurretPlayer();
        }

        if (_shootTimer <= 0)
        {
            _shootTimer = _currentTimer;
        }
    }

    private void TurretPlayer()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

        if (hit)
        {
            if (hitInfo.transform.gameObject.tag == "Hostile")
            {
                GameObject aBullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                _hostile = hitInfo.transform.gameObject;
                aBullet.transform.LookAt(_hostile.transform);
                aBullet.GetComponent<Bullet>()._target = _hostile;
            }
            /*else
            {
                Instantiate(laserPrefab, transform.position, laserPrefab.transform.rotation);

                laserPrefab.GetComponent<Laser>().worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //laserPrefab.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                //laserPrefab.transform.position = Vector3.MoveTowards(laserPrefab.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), step);
            }*/
        }
    }
}
