using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuilder : MonoBehaviour
{

    [SerializeField] private GameObject _tower;
    [SerializeField] private Color _selectedColor;

    public GameObject _selectedTower;
    public GameObject _buildLocation;
    private Vector3 _towerSpawn;

    private new MeshRenderer renderer;
    [SerializeField] private Color _towerDefaultColor;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    void SpawnLaserTurret()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _selectedTower != null)
        {
            Instantiate(_tower, _towerSpawn, _selectedTower.transform.rotation);
        }
    }

    void SelectTowerBuilder()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            
            if (hit)
            {
                if (hitInfo.transform.gameObject.tag == "TowerBuilder")
                {
                    //_towerDefaultColor = gameObject.GetComponent<Renderer>().material.color;
                    _selectedTower = hitInfo.transform.gameObject;
                    _towerSpawn = new Vector3(_selectedTower.transform.position.x, _buildLocation.transform.position.y, _selectedTower.transform.position.z);
                    _selectedTower.GetComponent<Renderer>().material.color = _selectedColor;
                    Debug.Log(_selectedTower.name);
                }
                else
                {
                    // add revert material
                    if (_selectedTower != null)
                    {
                        _towerDefaultColor = gameObject.GetComponent<Renderer>().material.color;
                        _selectedTower.GetComponent<Renderer>().material.color = _towerDefaultColor;
                        _selectedTower = null;
                    }
                }
            }
            // Make Select and Deselect Tower functions that only handle the colour
        }
        SpawnLaserTurret();
    }

    public void Update()
    {
        SelectTowerBuilder();
    }
}
