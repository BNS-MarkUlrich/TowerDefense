using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Hostile[] _enemyTypes; // Use Prefab Variants
    [SerializeField] private Vector2 _minxMaxSpawnTime;

    public bool stopSpawning = false;

    //public Vector3 _spawnAtVector3; // Use for Java Parsing

    private float _nextSpawnTime;
    public float _enemySpawnTimer;
    public float _numberOfBosses;

    private float _waveNumber;
    private bool _startLevel;

    public float minxMaxSpawnTimeX;
    public float minxMaxSpawnTimeY;

    public States currentWave = States.StartGame;

    private void Start()
    {
        _nextSpawnTime = Random.Range(_minxMaxSpawnTime.x, _minxMaxSpawnTime.y);
    }
    private void Update()
    {
        _waveNumber = FindObjectOfType<WaveHandler>()._waveNumber;
        _startLevel = FindObjectOfType<WaveHandler>()._startLevel;
        _enemySpawnTimer += Time.deltaTime;

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
            case States.StartGame:
                if (_startLevel == true)
                {
                    currentWave = States.Wave1;
                }
                break;
            case States.Wave1:
                if (_waveNumber == 1)
                {
                    Instantiate(_enemyTypes[0], transform.position, _enemyTypes[0].transform.rotation, transform);
                }
                else
                {
                    _numberOfBosses = 0;
                    currentWave = States.Wave2;
                }
                break;
            case States.Wave2:
                if (_waveNumber == 2)
                {
                    minxMaxSpawnTimeX = _minxMaxSpawnTime.x / 1.5f; // Doesn't work yet
                    minxMaxSpawnTimeY = _minxMaxSpawnTime.y / 1.5f; // Doesn't work yet
                    _nextSpawnTime = Random.Range(_minxMaxSpawnTime.x, _minxMaxSpawnTime.y);
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
                    _nextSpawnTime = Random.Range(_minxMaxSpawnTime.x, _minxMaxSpawnTime.y);
                    NormalWave();
                }
                else
                {
                    _numberOfBosses = 0;
                    currentWave = States.Wave4;
                }
                break;
            case States.Wave4:
                if (_waveNumber == 4)
                {
                    minxMaxSpawnTimeX = _minxMaxSpawnTime.x / 1.5f; // Doesn't work yet
                    minxMaxSpawnTimeY = _minxMaxSpawnTime.y / 1.5f; // Doesn't work yet
                    _nextSpawnTime = Random.Range(minxMaxSpawnTimeX, minxMaxSpawnTimeY);
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
                    bool activate = true;
                    FindObjectOfType<LaneActivator>()._medium = activate;
                    _nextSpawnTime = Random.Range(_minxMaxSpawnTime.x, _minxMaxSpawnTime.y);
                    NormalWave();
                }
                else
                {
                    _numberOfBosses = 0;
                    currentWave = States.Wave6;
                }
                break;
            case States.Wave6:
                if (_waveNumber == 6)
                {
                    minxMaxSpawnTimeX = _minxMaxSpawnTime.x / 1.5f; // Doesn't work yet
                    minxMaxSpawnTimeY = _minxMaxSpawnTime.y / 1.5f; // Doesn't work yet
                    _nextSpawnTime = Random.Range(minxMaxSpawnTimeX, minxMaxSpawnTimeY);
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
                    bool activate = true;
                    FindObjectOfType<LaneActivator>()._hard = activate;
                    _nextSpawnTime = Random.Range(_minxMaxSpawnTime.x, _minxMaxSpawnTime.y);
                    NormalWave();
                }
                else
                {
                    _numberOfBosses = 0;
                    currentWave = States.Wave8;
                }
                break;
            case States.Wave8:
                if (_waveNumber == 8)
                {
                    minxMaxSpawnTimeX = _minxMaxSpawnTime.x / 1.5f; // Doesn't work yet
                    minxMaxSpawnTimeY = _minxMaxSpawnTime.y / 1.5f; // Doesn't work yet
                    _nextSpawnTime = Random.Range(minxMaxSpawnTimeX, minxMaxSpawnTimeY);
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
                    bool activate = true;
                    FindObjectOfType<LaneActivator>()._veryHard = activate;
                    _nextSpawnTime = Random.Range(_minxMaxSpawnTime.x, _minxMaxSpawnTime.y);
                    NormalWave();
                }
                else
                {
                    _numberOfBosses = 0;
                    currentWave = States.Wave10;
                }
                break;
            case States.Wave10:
                if (_waveNumber == 10)
                {
                    minxMaxSpawnTimeX = _minxMaxSpawnTime.x / 1.5f; // Doesn't work yet
                    minxMaxSpawnTimeY = _minxMaxSpawnTime.y / 1.5f; // Doesn't work yet
                    _nextSpawnTime = Random.Range(minxMaxSpawnTimeX, minxMaxSpawnTimeY);
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
                    minxMaxSpawnTimeX = _minxMaxSpawnTime.x / 2f; // Doesn't work yet
                    minxMaxSpawnTimeY = _minxMaxSpawnTime.y / 2f; // Doesn't work yet
                    _nextSpawnTime = Random.Range(minxMaxSpawnTimeX, minxMaxSpawnTimeY);
                    NormalWave();
                    Invoke("SpawnBoss", 60);
                }
                else
                {
                    currentWave = States.SuperWave;
                }
                break;
            default:
                break;
        }

        _enemySpawnTimer = 0;
        _nextSpawnTime = Random.Range(_minxMaxSpawnTime.x, _minxMaxSpawnTime.y);
    }

    private void NormalWave()
    {
        int randomIndex = Random.Range(0, _enemyTypes.Length-1);
        Instantiate(_enemyTypes[randomIndex], transform.position, transform.rotation, transform);
    }

    private void SpawnBoss()
    {
        if (_numberOfBosses <= 0)
        {
            Instantiate(_enemyTypes[4], transform.position, transform.rotation, transform);
            _numberOfBosses += 1;
        }
    }

    public enum States
    {
        StartGame, // No enemies, build state only
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