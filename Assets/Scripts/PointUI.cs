using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointUI : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void UpdateUI(float currentPoints)
    {
        _text.text = "Points: " + currentPoints;
    }
}
