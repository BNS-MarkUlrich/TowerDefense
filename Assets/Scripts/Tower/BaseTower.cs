using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [SerializeField] protected bool _detected;

    public bool _startTimer;
    public float _towerTimer = 60f;
    private float _saveTowerTimer;
    public float _towerPriceModifier;

    private void Start()
    {
        _saveTowerTimer = _towerTimer;
    }

    public virtual void Update()
    {
        _detected = gameObject.GetComponentInParent<Detection>()._detection;

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
        if (_towerTimer <= 0)
        {
            Destroy(gameObject.GetComponentInParent<Wrapper>().gameObject);
            _startTimer = false;
        }
    }
}