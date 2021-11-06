using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    //[SerializeField] private GameObject laserPrefab;

    public float _speed;
    public GameObject _hostile;
    public GameObject[] _bulletTypes;

    public float _shootTimer = 1;
    public float _currentTimer;

    public PointSystem _pointSystem;
    public bool _boughtUpgrade;

    public MessagesUI _message;

    //public float _shootTimer = 0.1f;
    [SerializeField] private LayerMask _layer;

    private void Start()
    {
        _message = FindObjectOfType<MessagesUI>();
        _pointSystem = FindObjectOfType<PointSystem>();
        _currentTimer = _shootTimer;
    }

    void Update()
    {
        BuyUpgrade();
        if (Input.GetMouseButtonDown(0))
        {
            TurretPlayer(_bulletTypes[0]);
        }

        if (Input.GetMouseButtonDown(1) && _boughtUpgrade == true)
        {
            TurretPlayer(_bulletTypes[1]);
        }

        _shootTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && _shootTimer < 0)
        {
            TurretPlayer(_bulletTypes[0]);
        }

        if (Input.GetMouseButton(1) && _shootTimer < 0 && _boughtUpgrade == true)
        {
            TurretPlayer(_bulletTypes[1]);
        }

        if (_shootTimer <= 0)
        {
            _shootTimer = _currentTimer;
        }
    }

    private void TurretPlayer(GameObject bulletPrefab)
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

    private void BuyUpgrade()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4) && _pointSystem._currentPoints >= 3000)
        {
            if (_boughtUpgrade == true)
            {
                _message.EnableMessageUI("You already own this upgrade!");
            }
            else
            {
                _boughtUpgrade = true;
                _pointSystem.RemovePoints(3000);
                _message.EnableMessageUI("Player Upgrade bought, press [M2] to fire rockets!");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && _pointSystem._currentPoints < 3000)
        {
            if (_boughtUpgrade == true)
            {
                _message.EnableMessageUI("You already own this upgrade!");
            }
            else
            {
                float pointsShortF = 3000 - _pointSystem._currentPoints;
                int pointsShort = Mathf.RoundToInt(pointsShortF);
                _message.EnableMessageUI("You need " + pointsShort + " more points to buy the Player Upgrade");
            }
        }
    }
}