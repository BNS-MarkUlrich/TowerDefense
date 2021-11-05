using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    public LevelTimer _levelTimer;
    public float _waveTimer;
    public float _waveNumber;
    public bool _startLevel;

    public float _divideSpawnRate = 2f;

    private WaveUI _waveUI;

    private void Start()
    {
        _waveTimer = 10;
    }

    private void Update()
    {
        _levelTimer = FindObjectOfType<LevelTimer>();
        _waveUI = FindObjectOfType<WaveUI>();
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            _startLevel = true;
        }
        WaveCounter();
    }

    private void WaveCounter()
    {
        if (_startLevel == true)
        {
            if (_waveTimer <= _levelTimer.levelTimer + 10)
            {
                _waveTimer += 20;
                _waveNumber += 1;
                _waveUI.UpdateUI(_waveNumber);
            }
        }
    }
}
