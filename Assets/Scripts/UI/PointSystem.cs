using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public float _startPoints;
    public float _currentPoints;
    public float CurrentPoints
    {
        get { return _currentPoints; }
    }

    [SerializeField] private PointUI _pointUI;

    private void Start()
    {
        _currentPoints = _startPoints;
        _pointUI.UpdateUI(CurrentPoints);
    }
    public void AddPoints(float points)
    {
        _currentPoints += points;
        _pointUI.UpdateUI(CurrentPoints);
    }

    public void RemovePoints(float points)
    {
        if (_currentPoints <= 0)
        {
            _currentPoints = 0;
        }
        else
        {
            _currentPoints -= points;
            _pointUI.UpdateUI(CurrentPoints);
        }
    }
}
