using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveNameUI : MonoBehaviour
{
    [SerializeField] private Text _waveText;

    [SerializeField] private float _waveTimer = 60;
    [SerializeField] private float _localWaveTimer;

    private void Start()
    {
        _localWaveTimer = _waveTimer;
    }

    private void Update()
    {
        bool startLevel = FindObjectOfType<WaveHandler>()._startLevel;
        if (startLevel == true)
        {
            _localWaveTimer -= Time.deltaTime;
            if (_localWaveTimer <= 0)
            {
                _localWaveTimer = _waveTimer;
            }
            string.Format("{0:00}", _localWaveTimer);
        }
    }

    public void UpdateWaveName(string waveName)
    {
        _waveText.text = string.Format("{0:00}", _localWaveTimer) + ": " + waveName;
    }
}
