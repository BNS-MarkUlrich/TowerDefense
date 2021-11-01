using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] public float _startHealth = 3;
    public float _currentHealth;

    public virtual void Start()
    {
        //_startHealth = FindObjectOfType<PointSystem>()._startPoints; // Merge point and health system?
        //_currentHealth = FindObjectOfType<PointSystem>()._currentPoints; // Merge point and health system?
        _currentHealth = _startHealth;
    }

    public virtual void TakeDamage(float dmg)
    {
        _currentHealth -= dmg;
        if (_currentHealth <= 0)
        {
            DeadState();
        }
    }

    public virtual void DeadState()
    {
        if (_currentHealth <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
