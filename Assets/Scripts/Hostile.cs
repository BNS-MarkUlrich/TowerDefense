using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hostile : Health
{
    [SerializeField] private UnityEvent onPathComplete;
    [SerializeField] private BaseLocation.Destination _destination;
    [SerializeField] public float _speed = 5.0f;
    [SerializeField] public float _arrivalthreshold = 0.1f;

    public EnemyHealthDisplay healthbarValue;
    private EnemyHealthDisplay updateHealthbar;

    private float _hostileHeight;

    public Hostile _hostile;

    [SerializeField] public float _damageAmount;

    public Health _playerHealth;

    private PointSystem _pointSystem;

    public override void Start()
    {
        base.Start();
        SetupEnemy();
    }

    private void Awake()
    {
        _hostileHeight = transform.localScale.y / 2;
        if (_destination == null)
        {
            _destination = GameObject.FindObjectOfType<BaseLocation.Destination>();
        }
    }

    public void SetupEnemy()
    {
        _playerHealth = GameObject.FindWithTag("PlayerBase").GetComponent<Health>();
        _hostile.onPathComplete.AddListener(() => _playerHealth.TakeDamage(_damageAmount));
        updateHealthbar = healthbarValue.GetComponentInChildren<EnemyHealthDisplay>();
        updateHealthbar.Initialise(_startHealth, _currentHealth);
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        //_pointSystem.AddPoints(10);
    }

    public override void DeadState()
    {
        base.DeadState();
        _pointSystem.AddPoints(100);
    }

    private void Update()
    {
        Vector3 heightOffsetPosition = new Vector3(_destination.transform.position.x, _hostileHeight, _destination.transform.position.z);
        float distance = Vector3.Distance(transform.position, heightOffsetPosition);

        if (distance <= _arrivalthreshold)
        {
            onPathComplete?.Invoke();
            Destroy(this.gameObject);
        }

        transform.LookAt(heightOffsetPosition);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        _pointSystem = FindObjectOfType<PointSystem>();
        updateHealthbar.UpdateHP(_currentHealth);
    }
}