using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointUI : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void UpdateUI(float currentPoints)
    {
        _text.text = string.Format("{0}{1:0000}", "Points: ", currentPoints);
    }
}