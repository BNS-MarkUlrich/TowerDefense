using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public float _speed;
    public GameObject _hostile;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject laserPrefab;

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
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                if (hitInfo.transform.gameObject.tag == "Hostile")
                {
                    _hostile = hitInfo.transform.gameObject;
                    GameObject abullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                    abullet.transform.LookAt(_hostile.transform);
                    abullet.GetComponent<Bullet>()._target = _hostile;
                    //_hostile.GetComponent<Health>().TakeDamage(1);
                }
                /*else
                {
                    Instantiate(laserPrefab, transform.position, laserPrefab.transform.rotation);

                    float step = _speed * Time.deltaTime; // calculate distance to move
                    laserPrefab.GetComponent<Laser>().worldPoint = Input.mousePosition;
                    laserPrefab.transform.LookAt(Input.mousePosition);
                    laserPrefab.transform.position = Vector3.MoveTowards(laserPrefab.transform.position, Input.mousePosition, step);
                    //laserPrefab.transform.position = transform.forward;
                }*/
            }
        }
    }
}
