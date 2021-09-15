using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BaseLocation
{
    public class Hostile : MonoBehaviour
    {
        [SerializeField] private UnityEvent onPathComplete;
        
        [SerializeField] private Destination _destination;

        [SerializeField] public float _speed = 5.0f;
        [SerializeField] public float _arrivalthreshold = 0.1f;

        private float _hostileHeight;

        private void Awake()
        {
            _hostileHeight = transform.localScale.y / 2;
            if (_destination == null)
            {
                _destination = GameObject.FindObjectOfType<Destination>();
            }
        }

        private void Update()
        {
            Vector3 heightOffsetPosition = new Vector3(_destination.transform.position.x, _hostileHeight, _destination.transform.position.z);
            float distance = Vector3.Distance(transform.position, heightOffsetPosition);

            if(distance <= _arrivalthreshold)
            {
                onPathComplete?.Invoke();
            }

            transform.LookAt(heightOffsetPosition);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}
