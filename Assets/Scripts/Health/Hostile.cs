using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hostile : Health
{
    [SerializeField] protected UnityEvent onPathComplete;
    public float _speed = 5.0f;
    private float _arrivalthreshold = 0.1f;

    public HealthDisplay healthbarValue;
    private HealthDisplay updateHealthbar;

    //private float _hostileHeight;
    //private Hostile _hostile;
    public float _damageAmount;
    private Health _playerHealth;

    protected PointSystem _pointSystem;
    public float _pointsPerKill = 1;
    public float _pointDrain;

    public float _slowTimer = 1;
    private float _originalTimer;
    private float _originalSpeed;

    private Path _getPath;
    public Waypoint _currentWaypoint;

    public override void Start()
    {
        base.Start();
        SetupEnemy();
    }

    public void Awake()
    {
        //_hostileHeight = transform.localScale.y * 2;
        _getPath = GetComponentInParent<Path>();
    }

    public void SetupEnemy()
    {
        _playerHealth = GameObject.FindWithTag("PlayerBase").GetComponent<Health>();
        onPathComplete.AddListener(() => _playerHealth.TakeDamage(_damageAmount));
        updateHealthbar = healthbarValue.GetComponentInChildren<HealthDisplay>();
        updateHealthbar.Initialise(_startHealth, _currentHealth);
        _originalSpeed = _speed;
        _originalTimer = _slowTimer;
        _currentWaypoint = _getPath.GetPathStart();
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }

    public override void DeadState()
    {
        if (_playerHealth != null)
        {
            if (_currentHealth <= 0)
            {
                Destroy(this.gameObject);
                _pointSystem.AddPoints(_pointsPerKill);
            }
        }
        else
        {
            //Debug.Log("I am dead!");
            Destroy(this.gameObject);
        }
    }

    public void SlowEnemy()
    {
        StartCoroutine(SlowTimer());
    }

    public IEnumerator SlowTimer()
    {
        _speed = _originalSpeed / 2f;
        yield return new WaitForSeconds(_slowTimer);
        _speed = _originalSpeed;
        _slowTimer = _originalTimer;
    }

    public virtual void Update()
    {
        if (_playerHealth != null)
        {
            float hostileHeight = transform.localScale.y * 2;
            Vector3 heightOffsetPosition = new Vector3(_currentWaypoint.transform.position.x, hostileHeight, _currentWaypoint.transform.position.z);
            float distance = Vector3.Distance(transform.position, heightOffsetPosition);

            if (distance <= _arrivalthreshold)
            {
                if (_currentWaypoint == _getPath.GetPathEnd())
                {
                    onPathComplete?.Invoke();
                    _pointSystem.RemovePoints(_pointDrain);
                    Destroy(this.gameObject);
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
            _pointSystem = FindObjectOfType<PointSystem>();
            updateHealthbar.UpdateHP("", _currentHealth);
        }
    }
}