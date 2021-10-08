using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    [SerializeField] private float _startPoints;
    public float _currentPoints;
    public float CurrentPoints
    {
        get { return _currentPoints; }
    }

    [SerializeField] private PointUI _pointUI;
    [SerializeField] private MessagesUI _notEnoughMessage;

    private void Start()
    {
        _currentPoints = _startPoints;
        _pointUI.UpdateUI(CurrentPoints);
        _notEnoughMessage.EnableMessageUI("Dit is mijn message");
    }

    public void NotEnoughPoints()
    {
        //_notEnoughMessage.NotEnoughPointsUI(CurrentPoints);
    }

    public void AddPoints(float points)
    {
        _currentPoints += points;
        _pointUI.UpdateUI(CurrentPoints);
    }

    public void RemovePoints(float points)
    {
        _currentPoints -= points;
        _pointUI.UpdateUI(CurrentPoints);
    }
}
