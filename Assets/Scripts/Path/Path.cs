using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// De path class beheerd een array van waypoints. En houd bij bij welk waypoint een object is.
/// Deze vormen samen het pad. 
/// Logica die op het path niveau plaatsvindt gebeurt in deze class.
/// Een deel van de functies welke je nodig hebt zijn hier al beschreven.
/// </summary>
public class Path : MonoBehaviour
{
    [SerializeField] private Waypoint[] _waypoints;

    /// <summary>
    /// Get the start of the path
    /// </summary>
    /// <returns>First waypoint</returns>
    public Waypoint GetPathStart()
    {
        return _waypoints[0];
    }

    /// <summary>
    /// Get the end of the path
    /// </summary>
    /// <returns>Last waypoint</returns>
    public Waypoint GetPathEnd()
    {
        return _waypoints[_waypoints.Length - 1];
    }

    /// <summary>
    /// Deze functie returned het volgende waypoint waar naartoe kan worden bewogen
    /// </summary>
    /// <param name="currentWaypoint">Geef me huidige waypoint referentie.</param>
    /// <returns>Geeft null terug wanneer laatste waypoint is bereikt, als currentWaypoint null is geeft hij de eerste in de lijst terug.</returns>
    public Waypoint GetNextWaypoint(Waypoint currentWaypoint)
    {

        if (currentWaypoint == null)
        {
            return _waypoints[0];
        }

        for (int i = 0; i < _waypoints.Length; i++)
        {
            if (i == _waypoints.Length - 1)
            {
                return null;
            }
            else if (currentWaypoint == _waypoints[i])
            {
                return _waypoints[++i];
            }
        }

        // TODO: If valid reference but not in array == append to array

        return null;
    }
}