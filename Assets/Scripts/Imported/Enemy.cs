using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;


namespace PathFollower
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] public UnityEvent onPathComplete;
        [SerializeField] public float _speed = 3.0f;
        [SerializeField] private float _arrivalthreshold = 0.1f;
        [SerializeField] private Path _Path;
        private Waypoint currentWaypoint;

        private float _enemyHeight;

        private void Awake()
        {
            //_Path = GameObject.FindObjectOfType<Path>();
            currentWaypoint = _Path.GetNextWaypoint(currentWaypoint);
            _enemyHeight = transform.localScale.y / 2;
        }

        private void Update()
        {
            Vector3 heightOffsetPosition = new Vector3(currentWaypoint.WaypointLocation.x, _enemyHeight, currentWaypoint.WaypointLocation.z); // was transform.position.y
            float distance = Vector3.Distance(transform.position, heightOffsetPosition);

            if (distance <= _arrivalthreshold)
            {
                currentWaypoint = _Path.GetNextWaypoint(currentWaypoint);
                if(currentWaypoint == null)
                {
                    onPathComplete?.Invoke();
                }
            }
            else
            {
                transform.LookAt(heightOffsetPosition);
                transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            }
        }
    }
}