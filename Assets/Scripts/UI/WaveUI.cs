using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void UpdateUI(float currentWave)
    {
        _text.text = "Wave: " + currentWave;
    }
}
