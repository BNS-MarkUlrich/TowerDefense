using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;


namespace BaseLocation
{
    public class Towers : MonoBehaviour
    {
        protected TurretRangeChecker _rangeChecker;
        protected bool _isShooting = false;
        [SerializeField] protected float _damageAmount;

        private void Awake()
        {
            _rangeChecker = GetComponent<TurretRangeChecker>();
        }

        void Update()
        {
            // als we niet kunnen aanvallen. Ga dan uit de update functie
            if (!CanAttack()) return;

            Attack();
        }

        public virtual bool CanAttack()
        {
            return false;
        }

        protected virtual void Attack()
        {

        }
    }
}