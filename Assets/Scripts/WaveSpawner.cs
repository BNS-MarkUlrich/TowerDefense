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

    public void Start()
    {
        _waveTimer = 10;
        _nextSpawnTime = Random.Range(_minxMaxSpawnTime.x, _minxMaxSpawnTime.y);
    }
    public void Update()
    {
        _levelTimer = FindObjectOfType<LevelTimer>().levelTimer;
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
        int randomIndex = Random.Range(0, _enemyTypes.Length);
        //_spawnLocation.transform.position = new Vector3(_spawnLocation.transform.position.x, _spawnLocation.transform.position.y, _spawnLocation.transform.position.z);
        Instantiate(_enemyTypes[randomIndex], transform.position, transform.rotation, transform);

        _enemySpawnTimer = 0;
        _nextSpawnTime = Random.Range(_minxMaxSpawnTime.x, _minxMaxSpawnTime.y);
    }

    private void WaveHandler()
    {
        if (_waveTimer <= _levelTimer + 10)
        {
            _waveTimer += 10;
            _waveNumber += 1;
        }
    }
}