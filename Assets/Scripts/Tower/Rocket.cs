using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    public Hostile[] _hostilesInRange;

    public override void Update()
    {
        _hostilesInRange = gameObject.GetComponent<Detection>().AllInRangeChecker();
        base.Update();
    }
    public override void CannonFire()
    {
        if (_target != null)
        {
            Vector3 heightOffsetPosition = new Vector3(_target.transform.position.x, _target.transform.position.y, _target.transform.position.z);
            float distance = Vector3.Distance(transform.position, heightOffsetPosition);
            transform.LookAt(_target.transform.position);
            if (distance <= _arrivalthreshold)
            {
                if (_hostilesInRange != null)
                {
                    foreach (var hostile in _hostilesInRange)
                    {
                        hostile.GetComponent<Hostile>().TakeDamage(_damage);
                    }
                }
                else
                {
                    _hostilesInRange = gameObject.GetComponent<Detection>().AllInRangeChecker();
                }
                Destroy(this.gameObject);
            }
            float step = _speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}