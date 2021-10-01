using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hostile : MonoBehaviour
{
    [SerializeField] private UnityEvent onPathComplete;
    [SerializeField] private BaseLocation.Destination _destination;
    [SerializeField] public float _speed = 5.0f;
    [SerializeField] public float _arrivalthreshold = 0.1f;
    private float _hostileHeight;

    public Hostile _hostile;

    [SerializeField] public float _damageAmount;
    //public Health _currenEnemyHealth;

    public Health _playerHealth;

    private void Start()
    {
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
    }

    /*public void DeadState()
    {
        if (_currenEnemyHealth <= 0)
        {
            Debug.Log("I am dead");
            Destroy(this.gameObject);
        }
    }*/

    private void Update()
    {
        //_currenEnemyHealth = gameObject.GetComponent<Health>();
        Vector3 heightOffsetPosition = new Vector3(_destination.transform.position.x, _hostileHeight, _destination.transform.position.z);
        float distance = Vector3.Distance(transform.position, heightOffsetPosition);

        if (distance <= _arrivalthreshold)
        {
            onPathComplete?.Invoke();
            Destroy(this.gameObject);
        }

        transform.LookAt(heightOffsetPosition);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}