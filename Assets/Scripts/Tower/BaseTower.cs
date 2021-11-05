using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [SerializeField] protected bool _detected;

    public bool _startTimer;
    public float _towerTimer = 60f;
    public float _saveTowerTimer;
    public float _towerPriceModifier;

    public HealthDisplay healthbarValue;
    private HealthDisplay updateHealthbar;

    public virtual void Start()
    {
        _saveTowerTimer = _towerTimer;

        updateHealthbar = healthbarValue.GetComponentInChildren<HealthDisplay>();
        updateHealthbar.Initialise(_saveTowerTimer, _towerTimer);
    }

    public virtual void Update()
    {
        _detected = gameObject.GetComponentInParent<Detection>()._detection;
        _towerPriceModifier = _towerTimer / _saveTowerTimer;
        _startTimer = FindObjectOfType<TowerBuilder>()._startTimer;
        bool startLevel = FindObjectOfType<WaveHandler>()._startLevel;
        if (startLevel == true)
        {
            if (_startTimer == true)
            {
                TowerTimer();
            }
        }
    }

    public void TowerTimer()
    {
        _towerTimer -= Time.deltaTime;
        updateHealthbar.UpdateHP("Timer: ", _towerTimer);
        if (_towerTimer <= 0)
        {
            Destroy(gameObject.GetComponentInParent<Wrapper>().gameObject);
            _startTimer = false;
        }
    }
}