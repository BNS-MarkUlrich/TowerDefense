using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Bullet
{
    public Vector3 worldPoint;

    public override void Update()
    {
        base.Update();
    }
    public override void CannonFire()
    {
        Vector3 heightOffsetPosition = new Vector3(-worldPoint.x, -worldPoint.y, -worldPoint.z);
        float distance = Vector3.Distance(transform.position, heightOffsetPosition);
        transform.LookAt(worldPoint);
        if (distance <= _arrivalthreshold)
        {
            Destroy(this.gameObject);
        }
        float step = _speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, worldPoint, step);
    }
}