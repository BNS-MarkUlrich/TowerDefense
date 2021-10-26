using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void UpdateUI(float currentHealth)
    {
        _text.text = "Health: " + currentHealth;
    }
}