using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BaseLocation
{
    /// <summary>
    /// Stores location of parent GameObject.
    /// </summary>
    public class Destination : MonoBehaviour
    {
        public Vector3 DestinationLocation { get { return transform.position; } }
    }
}