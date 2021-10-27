using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private LayerMask _layer;

    public bool _detection = false;

    private void Update()
    {
        RangeChecker();
        //Debug.Log(_detection);
    }

    public GameObject RangeChecker()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _layer);
        if (hitColliders.Length < 1)
        {
            _detection = false;
            return null;
        }
        else
        {
            //Debug.Log(hitColliders[0]);
            _detection = true;

            return hitColliders[0].gameObject;
        }
    }

    public Health[] AllInRangeChecker()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _layer);
        if (hitColliders.Length < 1)
        {
            _detection = false;
            return null;
        }
        else
        {
            _detection = true;
            List<Health> objectsInRange = new List<Health>();
            foreach (var hitCollider in hitColliders)
            {
                objectsInRange.Add(hitCollider.GetComponent<Health>());
            }

            return objectsInRange.ToArray();
        }
    }

    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
