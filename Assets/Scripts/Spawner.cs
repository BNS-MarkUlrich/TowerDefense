using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public bool isPlayer = false;
    public float spawnTime;
    public float spawnDelay;
    public float deadPlayer;

    [SerializeField] private Vector3 _spawnAtVector3;
    [SerializeField] private GameObject _objectHeight;

    private void Start()
    {
        _spawnAtVector3 = new Vector3(_spawnAtVector3.x, _objectHeight.transform.position.y, _spawnAtVector3.z);

        if (isPlayer == true)
        {
            Invoke("SpawnPlayer", spawnDelay); // Spawn player once
        }
        else
        {
            InvokeRepeating("SpawnObject", spawnTime, spawnDelay); // Spawn enemies by interval
        }
    }
    /// <summary>
    /// <param name="SpawnObject">This function handles the spawning of objects. Object reference and Vector3 location are handled in the inspector or through code</param>
    /// </summary>
    public void SpawnObject()
    {
        Instantiate(spawnee, _spawnAtVector3, transform.rotation); // _spawnAtVector3 was transform.position (for drag/drop spawn locations)
        /*if (deadPlayer == 0) // WIP feature, not related to the assignment
        {
            stopSpawning = true;
        }*/

        if (stopSpawning)
        {
            // Do something
            CancelInvoke("SpawnObject");
        }
    }

    public void SpawnPlayer()
    {
        Instantiate(spawnee, _spawnAtVector3, transform.rotation);
    }
}
