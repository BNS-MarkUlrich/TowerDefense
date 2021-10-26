using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuilder : MonoBehaviour
{

    [SerializeField] private GameObject _tower;
    [SerializeField] private Color _selectedColor;

    public GameObject _selectedTower;
    private Vector3 _towerSpawn;

    private new MeshRenderer renderer;
    [SerializeField] private Color _towerDefaultColor;

    public States currenState = States.SELECTIONSTATE;

    private float _points;
    private PointSystem _pointSystem;
    private MessagesUI _message;

    public bool _canBuild;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        _message = FindObjectOfType<MessagesUI>();
    }

    void SpawnLaserTurret(GameObject tower)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && tower != null) // Laser Turret
        {
            if (_canBuild == true)
            {
                if (_points >= 500)
                {
                    _pointSystem.RemovePoints(500);
                    Instantiate(_tower, _towerSpawn, tower.transform.rotation);
                    _selectedTower.GetComponent<BuildOverride>()._canBuild = false;
                }
                else
                {
                    _message.EnableMessageUI(_points + " is not enough points");
                }
            }
            else
            {
                _message.EnableMessageUI("You cannot build on this tile!");
            }
            _selectedTower.GetComponent<Renderer>().material.color = _towerDefaultColor;
            currenState = States.SELECTIONSTATE;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && tower != null) // Rocket Tower
        {
            if (_canBuild == true)
            {
                if (_points >= 750)
                {
                    _pointSystem.RemovePoints(500);
                    Instantiate(_tower, _towerSpawn, tower.transform.rotation);
                    _selectedTower.GetComponent<BuildOverride>()._canBuild = false;
                }
                else
                {
                    _message.EnableMessageUI(_points + " is not enough points");
                }
            }
            else
            {
                _message.EnableMessageUI("You cannot build on this tile!");
            }
            _selectedTower.GetComponent<Renderer>().material.color = _towerDefaultColor;
            currenState = States.SELECTIONSTATE;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                if (hitInfo.transform.gameObject.tag != "TowerBuilder")
                {
                    _selectedTower.GetComponent<Renderer>().material.color = _towerDefaultColor;
                    _selectedTower = null;
                }
                else
                {
                    _selectedTower.GetComponent<Renderer>().material.color = _towerDefaultColor;
                    _selectedTower = null;
                }
            }
            currenState = States.SELECTIONSTATE;
        }
    }

    void SelectTowerBuilder()
    {
        switch (currenState)
        {
            case States.SELECTIONSTATE:
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hitInfo = new RaycastHit();
                    bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

                    if (hit)
                    {
                        if (hitInfo.transform.gameObject.tag == "TowerBuilder")
                        {
                            _selectedTower = hitInfo.transform.gameObject;
                            _towerSpawn = new Vector3(_selectedTower.transform.position.x, _selectedTower.transform.position.y, _selectedTower.transform.position.z);
                            _selectedTower.GetComponent<Renderer>().material.color = _selectedColor;
                            _canBuild = _selectedTower.GetComponent<BuildOverride>()._canBuild;
                            currenState = States.SPAWNSTATE;
                        }
                        else
                        {
                            // add revert material
                            if (_selectedTower != null)
                            {
                                _selectedTower.GetComponent<Renderer>().material.color = _towerDefaultColor;
                                _selectedTower = null;
                            }
                        }
                    }
                    // Make Select and Deselect Tower functions that only handle the colour
                }
                break;
            case States.SPAWNSTATE:
                SpawnLaserTurret(_selectedTower);
                break;
            default:
                _towerDefaultColor = gameObject.GetComponent<Renderer>().material.color;
                break;
        }
    }

    public void Update()
    {
        _points = FindObjectOfType<PointSystem>()._currentPoints;
        _pointSystem = FindObjectOfType<PointSystem>();
        SelectTowerBuilder();
    }
    public enum States
    {
        SELECTIONSTATE,
        SPAWNSTATE
    }

}
