using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseLocation
{
    public class TurretRangeChecker : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layer;

        public Hostile GetFirstEnemyInRange()
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
    }

}