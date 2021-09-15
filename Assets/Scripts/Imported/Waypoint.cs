using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathFollower
{
    public class Waypoint : MonoBehaviour
    {
        public Vector3 WaypointLocation { get { return transform.position; } }
    }
}