using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed;
    public float _arrivalthreshold = 0.1f;
    public GameObject _target;
    public float _damage = 1;

    public virtual void Update()
    {
        CannonFire();
    }

    public virtual void CannonFire()
    {
        if (_target != null)
        {
            Vector3 heightOffsetPosition = new Vector3(_target.transform.position.x, _target.transform.position.y, _target.transform.position.z);
            float distance = Vector3.Distance(transform.position, heightOffsetPosition);
            transform.LookAt(_target.transform.position);
            if (distance <= _arrivalthreshold)
            {
                _target.GetComponent<Health>().TakeDamage(_damage);
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