using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] _difficultyLanes;

    public bool _medium;
    public bool _hard;
    public bool _veryHard;

    void Update()
    {
        AddDifficultyLane();
    }

    private void AddDifficultyLane()
    {
        if (_medium == true)
        {
            _difficultyLanes[0].SetActive(true);
        }
        else if (_hard == true)
        {
            _difficultyLanes[1].SetActive(true);
        }
        else if (_veryHard == true)
        {
            _difficultyLanes[2].SetActive(true);
        }
    }
}