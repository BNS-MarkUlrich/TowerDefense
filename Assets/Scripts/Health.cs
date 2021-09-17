using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public float _startHealth = 3;
    public float _currentHealth;

    private new MeshRenderer renderer;

    public void Start()
    {
        _currentHealth = _startHealth;
    }

    public void TakeDamage(float dmg)
    {
        _currentHealth -= dmg;
        Debug.Log(_currentHealth);
        Debug.Log("I took damage!");

        if (_currentHealth <= 0)
        {
            StartCoroutine(PlayerDeadFeedback());
        }
    }
    IEnumerator PlayerDeadFeedback()
    {
        Material dmat = renderer.material;

        dmat.color -= new Color(0.2f, 0.2f, 0.2f, 3.8f);
        yield return null;
    }
}
