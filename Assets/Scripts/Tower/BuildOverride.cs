using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOverride : MonoBehaviour
{
    public bool _canBuild;
    public int _towerNumber;

    private void Start()
    {
        _canBuild = true;
    }
}