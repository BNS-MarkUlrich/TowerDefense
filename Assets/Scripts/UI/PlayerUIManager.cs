using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] protected HealthUI _healthUI;
    public float CurrentHealth;
    /*public float CurrentHealth
    {
        get { return _currentHealth; }
    }*/

    public void Start()
    {
        _healthUI = FindObjectOfType<HealthUI>();
        _healthUI.UpdateUI(CurrentHealth);
    }
    public void Update()
    {
        CurrentHealth = gameObject.GetComponent<Health>()._currentHealth;
        _healthUI.UpdateUI(CurrentHealth);
    }
}
