using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHostile : Health
{
    public float _speed = 5.0f;
    [SerializeField] private float _arrivalthreshold = 0.1f;

    public HealthDisplay healthbarValue;
    private HealthDisplay updateHealthbar;

    public Path _getPath;
    private Waypoint _currentWaypoint;

    public override void Start()
    {
        base.Start();
        SetupEnemy();
    }

    private void Awake()
    {
        //_hostileHeight = transform.localScale.y * 2;
        _getPath = GetComponentInParent<Path>();
    }

    public void SetupEnemy()
    {
        updateHealthbar = healthbarValue.GetComponentInChildren<HealthDisplay>();
        updateHealthbar.Initialise(_startHealth, _currentHealth);
        _currentWaypoint = _getPath.GetPathStart();
    }
    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }

    public override void DeadState()
    {
        if (_currentHealth <= 0)
        {
            _currentHealth = 3;
        }
    }
    private void Update()
    {
        Vector3 heightOffsetPosition = new Vector3(_currentWaypoint.transform.position.x, _currentWaypoint.transform.position.y, _currentWaypoint.transform.position.z);
        float distance = Vector3.Distance(transform.position, heightOffsetPosition);

        if (distance <= _arrivalthreshold)
        {
            if (_currentWaypoint == _getPath.GetPathEnd())
            {
                _currentWaypoint = _getPath.GetPathStart();
            }
            else
            {
                _currentWaypoint = _getPath.GetNextWaypoint(_currentWaypoint);
            }
        }
        else
        {
            transform.LookAt(heightOffsetPosition);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        updateHealthbar.UpdateHP("", _currentHealth);
    }
}
