using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeChecker : TowerManager
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layer;

    public Hostile GetHostileInRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, _radius, _layer);
        if (cols.Length < 1)
            return null;

        //else if (cols.Length >= 2)
        //{
        //    return cols[0].GetComponent<Enemy>();
        //}
        else
        {
            return cols[0].GetComponent<Hostile>();
            //Debug.Log(cols);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}