using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float _startHealth = 3;
    public float _currentHealth;

    //private new MeshRenderer renderer;

    public virtual void Start()
    {
        _currentHealth = _startHealth;
    }

    public virtual void TakeDamage(float dmg)
    {
        _currentHealth -= dmg;

        if (_currentHealth <= 0)
        {
            DeadState();
        }
    }

    public virtual void DeadState()
    {
        if (_currentHealth <= 0)
        {
            //Debug.Log("I am dead");
            Destroy(this.gameObject);
        }
    }

    /*IEnumerator PlayerDeadFeedback()
    {
        Material dmat = renderer.material;

        dmat.color -= new Color(0.2f, 0.2f, 0.2f, 3.8f);
        yield return null;
    }*/
}
