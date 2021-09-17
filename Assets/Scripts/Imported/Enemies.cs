using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public string _enemyName;
    public float _health;
    private float _damage;

    public float _takeDamage;
    public bool _isTakingDamage;
    public bool _enemyDead;

    public void Start()
    {
        
        _health = 100.0f;
        _damage = 10.0f;
    }

    public void Enemy(string enemyName, float enemyHealth, float enemyDamage)
    {
        enemyName = _enemyName;
        enemyHealth = _health;
        enemyDamage = _damage;
    }

    public void Update()
    {
        if (_isTakingDamage == true)
        {
            _health -= - _takeDamage;
        }
        else if (_health <= 0)
        {
            _enemyDead = true;
        }
    }
}
