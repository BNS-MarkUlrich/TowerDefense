using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetection : TowerManager
{
    protected Transform _target;
    [SerializeField] public float _range = 10f;

    public string _taggedHostile = "Hostile";

    public Transform _partToRotate;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] hostiles = GameObject.FindGameObjectsWithTag(_taggedHostile);
        
        for (int i = 0; i < hostiles.Length; i++)
        {
            Debug.Log(hostiles[i]);
        }
        float shortestDistance = Mathf.Infinity;
        GameObject nearestHostile = null;
        foreach (GameObject hostile in hostiles)
        {
            float distanceToHostile = Vector3.Distance(transform.position, hostile.transform.position);
            if (shortestDistance < distanceToHostile)
            {
                shortestDistance = distanceToHostile;
                nearestHostile = hostile;
            }
        }

        if (nearestHostile != null && shortestDistance <= _range)
        {
            _target = nearestHostile.transform;
            
        }
        else
        {
            _target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (_target == null)
        {
            return;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
