using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseLocation
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private Destination[] _destinations;


        public Destination GetNextDestination(Destination currentLocation)
        {
            if (currentLocation == null)
            {
                return _destinations[0];
            }

            for (int i = 0; i < _destinations.Length; i++)
            {
                if (i == _destinations.Length - 1)
                {
                    return null;
                }
                else if (currentLocation == _destinations[i])
                {
                    return _destinations[++i];
                }
            }


            return null;
        }
    }

}