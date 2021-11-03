using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretFire : MonoBehaviour
{
    public float _cooldownTimer;
    [SerializeField] private float _saveCooldownTimer;

    private void Start()
    {
        _saveCooldownTimer = _cooldownTimer;
    }

    private void Update()
    {
        _cooldownTimer -= Time.deltaTime;
        if (_cooldownTimer <= _saveCooldownTimer - 0.1)
        {
            _cooldownTimer = _saveCooldownTimer;
        }
    }
}