using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnee;

    //[SerializeField] private Vector3 _spawnAtVector3;
    //[SerializeField] private GameObject _objectHeight;

    public virtual void Start()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
    }
}