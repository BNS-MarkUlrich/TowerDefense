using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    [SerializeField] private float _startPoints;
    public float _currentPoints;

    private void Start()
    {
        _currentPoints = _startPoints;
    }

    public void AddPoints(float points)
    {
        _currentPoints += points;
    }

    public void RemovePoints(float points)
    {
        _currentPoints -= points;
    }
}
