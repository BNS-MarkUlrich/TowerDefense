using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuilder : MonoBehaviour
{

    [SerializeField] private GameObject[] _tower;
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
    public int _towerNumber;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        _message = FindObjectOfType<MessagesUI>();
    }

    void SpawnLaserTurret(GameObject tower)
    {
        if (_canBuild == true)
        {
            
            if (Input.GetKeyDown(KeyCode.Alpha1) && tower != null) // Stun Tower
            {
                TowerShop(_tower[0], 500, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && tower != null) // Laser Turret
            {
                TowerShop(_tower[1], 1000, 1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && tower != null) // Rocket Tower
            {
                TowerShop(_tower[2], 1500, 2);
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
        else // Put most of the stuff below into separate scripts
        {
            _message.EnableMessageUI("Select new tower...");
            if (Input.GetKeyDown(KeyCode.Alpha1) && tower != null) // Stun Tower
            {
                if (_towerNumber > 0)
                {
                    _message.EnableMessageUI("You cannot downgrade a tower!");
                    SwitchBackToSelection();
                }
                else
                {
                    _message.EnableMessageUI("This tower already exists on this tile!");
                    SwitchBackToSelection();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && tower != null) // Laser Turret
            {
                if (_towerNumber > 1)
                {
                    _message.EnableMessageUI("You cannot downgrade a tower!");
                    SwitchBackToSelection();
                }
                else if (_towerNumber == 1)
                {
                    _message.EnableMessageUI("This tower already exists on this tile!");
                    SwitchBackToSelection();
                }
                else
                {
                    UpgradeTower(_tower[0], _tower[1], 1000, 1);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && tower != null) // Rocket Tower
            {
                if (_towerNumber > 2)
                {
                    _message.EnableMessageUI("You cannot downgrade a tower!");
                    SwitchBackToSelection();
                }
                else if (_towerNumber == 2)
                {
                    _message.EnableMessageUI("This tower already exists on this tile!");
                    SwitchBackToSelection();
                }
                else
                {
                    UpgradeTower(_tower[1], _tower[2], 1500, 2);
                }
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
                            //_towerSpawn = _selectedTower.GetComponentInChildren<Transform>().position;
                            _selectedTower.GetComponent<Renderer>().material.color = _selectedColor;
                            _canBuild = _selectedTower.GetComponent<BuildOverride>()._canBuild;
                            _towerNumber = _selectedTower.GetComponent<BuildOverride>()._towerNumber; // Assigns tower index upon selection to keep track of upgrade possibilities
                            currenState = States.SPAWNSTATE;
                        }
                        else
                        {
                            if (_selectedTower != null)
                            {
                                _selectedTower.GetComponent<Renderer>().material.color = _towerDefaultColor;
                                _selectedTower = null;
                            }
                        }
                    }
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

    void TowerShop(GameObject tower, float points, int towerNumber)
    {
        if (_points >= points)
        {
            _pointSystem.RemovePoints(points);
            float towerHeightSpawn = _selectedTower.GetComponentInChildren<Transform>().position.y * 2;
            if (towerHeightSpawn == 0)
            {
                towerHeightSpawn += _selectedTower.transform.localScale.y / 2;
            }
            Vector3 towerSpawn = new Vector3(_selectedTower.transform.position.x, towerHeightSpawn, _selectedTower.transform.position.z);
            Instantiate(tower, towerSpawn, tower.transform.rotation, _selectedTower.transform.parent);
            _selectedTower.GetComponent<BuildOverride>()._canBuild = false;
            _selectedTower.GetComponent<BuildOverride>()._towerNumber = towerNumber; // Saves the index of spawned tower into class variable
        }
        else
        {
            float pointsShort = points - _points;
            _message.EnableMessageUI("You need " + pointsShort + " more points to buy " + tower.name);
        }
        SwitchBackToSelection();
    }
    void UpgradeTower(GameObject OldTower, GameObject NewTower, float points, int towerNumber)
    {
        if (_points >= points)
        {
            OldTower = _selectedTower.GetComponentInChildren<Wrapper>().gameObject;
            Destroy(OldTower);
            _pointSystem.RemovePoints(points);
            float towerHeightSpawn = _selectedTower.GetComponentInChildren<Transform>().position.y * 2;
            if (towerHeightSpawn == 0)
            {
                towerHeightSpawn += _selectedTower.transform.localScale.y / 2;
            }
            Vector3 towerSpawn = new Vector3(_selectedTower.transform.position.x, towerHeightSpawn, _selectedTower.transform.position.z);
            Instantiate(NewTower, towerSpawn, NewTower.transform.rotation, _selectedTower.transform.parent);
            _selectedTower.GetComponent<BuildOverride>()._canBuild = false;
            _selectedTower.GetComponent<BuildOverride>()._towerNumber = towerNumber; // Saves the index of spawned tower into class variable
        }
        else
        {
            float pointsShort = points - _points;
            _message.EnableMessageUI("You need " + pointsShort + " more points to buy " + NewTower.name);
        }
        SwitchBackToSelection();
    }

    void SwitchBackToSelection()
    {
        _selectedTower.GetComponent<Renderer>().material.color = _towerDefaultColor;
        currenState = States.SELECTIONSTATE;
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
