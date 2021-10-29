using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [SerializeField] protected bool _detected;

    public virtual void Update()
    {
        _detected = gameObject.GetComponentInParent<Detection>()._detection;
    }
}