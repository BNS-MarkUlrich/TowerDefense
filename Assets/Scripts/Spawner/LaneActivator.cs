using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] _difficultyLanes;

    public bool _medium;
    public bool _hard;
    public bool _veryHard;

    public void Update()
    {
        if (_medium == true)
        {
            _difficultyLanes[0].SetActive(_medium);
        }
        if (_hard == true)
        {
            _difficultyLanes[1].SetActive(_hard);
        }
        if (_veryHard == true)
        {
            _difficultyLanes[2].SetActive(_veryHard);
        }
    }
}