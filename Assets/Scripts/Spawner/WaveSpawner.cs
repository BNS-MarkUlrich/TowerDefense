using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Hostile[] _enemyTypes; // Use Prefab Variants
    [SerializeField] private Vector2 _minxMaxSpawnTime;

    public bool stopSpawning = false;

    //public Vector3 _spawnAtVector3; // Use for Java Parsing

    private float _nextSpawnTime;
    public float _enemySpawnTimer;
    public float _levelTimer;
    public float _waveTimer;
    public float _waveNumber;

    private WaveUI _waveUI;

    public States currentWave = States.Wave1;

    public void Start()
    {
        _waveTimer = 10;
        _nextSpawnTime = Random.Range(_minxMaxSpawnTime.x, _minxMaxSpawnTime.y);
    }
    public void Update()
    {
        _levelTimer = FindObjectOfType<LevelTimer>().levelTimer;
        _waveUI = FindObjectOfType<WaveUI>();
        _enemySpawnTimer += Time.deltaTime;
        WaveHandler();
        if (_enemySpawnTimer >= _nextSpawnTime)
        {
            SpawnNextEnemy();
        }
    }

    /// <summary>
    /// <param name="SpawnNextEnemy">This function handles the spawning of objects. Object reference and Vector3 location are handled in the inspector or through code</param>
    /// </summary>
    private void SpawnNextEnemy()
    {
        switch (currentWave)
        {
            case States.Wave1:
                if (_waveNumber == 1)
                {
                    Instantiate(_enemyTypes[0], transform.position, _enemyTypes[0].transform.rotation, transform);
                }
                else
                {
                    currentWave = States.Wave2;
                }
                break;
            case States.Wave2:
                if (_waveNumber == 2)
                {
                    Instantiate(_enemyTypes[0], transform.position, transform.rotation, transform);
                    Invoke("SpawnBoss", 1);
                }
                else
                {
                    currentWave = States.Wave3;
                }
                break;
            case States.Wave3:
                if (_waveNumber == 3)
                {
                    NormalWave();
                }
                else
                {
                    currentWave = States.Wave4;
                }
                break;
            case States.Wave4:
                if (_waveNumber == 4)
                {
                    NormalWave();
                    Invoke("SpawnBoss", 1);
                }
                else
                {
                    currentWave = States.Wave5;
                }
                break;
            case States.Wave5:
                if (_waveNumber == 5)
                {
                    // Add Medium lane
                    NormalWave();
                }
                else
                {
                    currentWave = States.Wave6;
                }
                break;
            case States.Wave6:
                if (_waveNumber == 6)
                {
                    // Add Medium lane ?
                    NormalWave();
                    Invoke("SpawnBoss", 1);
                }
                else
                {
                    currentWave = States.Wave7;
                }
                break;
            case States.Wave7:
                if (_waveNumber == 7)
                {
                    // Add Medium lane ?
                    // Add Hard Lane
                    NormalWave();
                }
                else
                {
                    currentWave = States.Wave8;
                }
                break;
            case States.Wave8:
                if (_waveNumber == 8)
                {
                    // Add Medium lane ?
                    // Add Hard Lane ?
                    NormalWave();
                    Invoke("SpawnBoss", 1);
                }
                else
                {
                    currentWave = States.Wave9;
                }
                break;
            case States.Wave9:
                if (_waveNumber == 9)
                {
                    // Add Medium lane ?
                    // Add Hard Lane ?
                    // Add Very Hard Lane
                    NormalWave();
                }
                else
                {
                    currentWave = States.Wave10;
                }
                break;
            case States.Wave10:
                if (_waveNumber == 10)
                {
                    // Add Medium lane ?
                    // Add Hard Lane ?
                    // Add Very Hard Lane ?
                    NormalWave();
                    Invoke("SpawnBoss", 1);
                }
                else
                {
                    currentWave = States.SuperWave;
                }
                break;
            case States.SuperWave:
                if (_waveNumber >= 10)
                {
                    // Add Medium lane ?
                    // Add Hard Lane ?
                    // Add Very Hard Lane ?
                    NormalWave();
                    if (_waveNumber == _waveNumber + 1)
                    {
                        Invoke("SpawnBoss", 1);
                    }
                }
                else
                {
                    currentWave = States.SuperWave;
                }
                break;
            default:
                break;
        }
        //_spawnLocation.transform.position = new Vector3(_spawnLocation.transform.position.x, _spawnLocation.transform.position.y, _spawnLocation.transform.position.z);
        Instantiate(_enemyTypes[0], transform.position, transform.rotation, transform);

        _enemySpawnTimer = 0;
        _nextSpawnTime = Random.Range(_minxMaxSpawnTime.x, _minxMaxSpawnTime.y);
    }

    private void WaveHandler()
    {
        if (_waveTimer <= _levelTimer + 10)
        {
            _waveTimer += 60;
            _waveNumber += 1;
            _waveUI.UpdateUI(_waveNumber);
        }
    }

    private void NormalWave()
    {
        int totalindex = _enemyTypes.Length;
        int waveindex = totalindex - _enemyTypes.Length + 4;
        int randomIndex = Random.Range(0, waveindex);
        Instantiate(_enemyTypes[randomIndex], transform.position, transform.rotation, transform);
    }

    private void SpawnBoss()
    {
        Instantiate(_enemyTypes[5], transform.position, transform.rotation, transform);
    }

    public enum States
    {
        Wave1,  // Only normal enemies
        Wave2,  // Boss Wave: 1 Boss per wavespawn
        Wave3,  // Add special enemies
        Wave4,  // Boss Wave: 1 Boss per wavespawn
        Wave5,  // Unlock Medium difficulty
        Wave6,  // Boss Wave: 1 Boss per wavespawn
        Wave7,  // Unlock Hard Difficulty
        Wave8,  // Boss Wave: 1 Boss per wavespawn
        Wave9,  // Unlock Very Hard Difficulty
        Wave10, // Boss Wave: 1 Boss per wavespawn
        SuperWave,  // Superwave: 1 Boss per wavespawn every added wave
    }
}