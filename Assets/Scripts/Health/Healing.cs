using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healing : MonoBehaviour
{
    private Health _playerHealth;
    private PointSystem _pointSystem;
    private MessagesUI _message;
    public float _healingCost;
    public float _healing;

    private void Start()
    {
        _message = FindObjectOfType<MessagesUI>();
        _pointSystem = FindObjectOfType<PointSystem>();
    }

    private void Update()
    {
        _playerHealth = GameObject.FindWithTag("PlayerBase").GetComponent<Health>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HealPlayer();
        }
    }

    public void HealPlayer()
    {
        if (_pointSystem._currentPoints >= _healingCost)
        {
            if (_playerHealth._currentHealth < 100)
            {
                _playerHealth._currentHealth += 10;
                if (_playerHealth._currentHealth > 100)
                {
                    _playerHealth._currentHealth = 100;
                }
                _pointSystem.RemovePoints(_healingCost);
                _message.EnableMessageUI("+" + _healing + " Healing Done");
            }
            else
            {
                _message.EnableMessageUI("You are at max Health");
            }
        }
        else
        {
            float pointsShort = _healingCost - _pointSystem._currentPoints;
            _message.EnableMessageUI("You need " + pointsShort + " more points");
        }
    }
}