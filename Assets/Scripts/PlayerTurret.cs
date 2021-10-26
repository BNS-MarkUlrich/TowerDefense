using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public GameObject _hostile;
    //public float _shootTimer = 0.1f;
    [SerializeField] private LayerMask _layer;

    void Update()
    {
        TurretPlayer();
    }

    private void TurretPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, _layer);
            if (hit)
            {
                if (hitInfo.transform.gameObject.tag == "Hostile")
                {
                    _hostile = hitInfo.transform.gameObject;
                    _hostile.GetComponent<Health>().TakeDamage(1);
                }
            }
        }
    }
}
