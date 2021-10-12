using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOverride : MonoBehaviour
{
    // Create script that changes a boolean once a tower has been placed and attach it to Build Location.
    // Upon selecting a Build Location which already contains a tower, the script can then either prevent
    // you from building or allow you to replace the already existing tower.
    // Potentially use collision to detect whether tower has been placed or not.

    public bool _canBuild;

    private void Start()
    {
        _canBuild = true;
    }
}