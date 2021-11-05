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
    public bool _startTimer;
    public int _towerNumber;

    private BaseTower _baseTower;

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
            _baseTower = _selectedTower.GetComponentInChildren<BaseTower>();
            if (Input.GetKeyDown(KeyCode.Alpha1) && tower != null) // Stun Tower
            {
                if (_towerNumber == 0)
                {
                    float _towerPrice = 500 - (500 * _baseTower._towerPriceModifier);
                    UpgradeTower(_tower[0], _tower[0], _towerPrice, 0);
                }
                else if (_towerNumber == 1)
                {
                    float _towerPrice = 500 - (1000 * _baseTower._towerPriceModifier);
                    UpgradeTower(_tower[1], _tower[0], _towerPrice, 0);
                }
                else if (_towerNumber == 2)
                {
                    float _towerPrice = 500 - (1500 * _baseTower._towerPriceModifier);
                    UpgradeTower(_tower[2], _tower[0], _towerPrice, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && tower != null) // Laser Turret
            {
                if (_towerNumber == 0)
                {
                    float _towerPrice = 1000 - (500 * _baseTower._towerPriceModifier);
                    UpgradeTower(_tower[0], _tower[1], _towerPrice, 1);
                }
                else if (_towerNumber == 1)
                {
                    float _towerPrice = 1000 - (1000 * _baseTower._towerPriceModifier);
                    UpgradeTower(_tower[1], _tower[1], _towerPrice, 1);
                }
                else if (_towerNumber == 2)
                {
                    float _towerPrice = 1000 - (1500 * _baseTower._towerPriceModifier);
                    UpgradeTower(_tower[2], _tower[1], _towerPrice, 1);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && tower != null) // Rocket Tower
            {
                if (_towerNumber == 0)
                {
                    float _towerPrice = 1500 - (500 * _baseTower._towerPriceModifier);
                    UpgradeTower(_tower[0], _tower[2], _towerPrice, 2);
                }
                else if (_towerNumber == 1)
                {
                    float _towerPrice = 1500 - (1000 * _baseTower._towerPriceModifier);
                    UpgradeTower(_tower[1], _tower[2], _towerPrice, 2);
                }
                else if (_towerNumber == 2)
                {
                    float _towerPrice = 1500 - (1500 * _baseTower._towerPriceModifier);
                    UpgradeTower(_tower[2], _tower[2], _towerPrice, 2);
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
            float towerHeightSpawn = tower.transform.localScale.y * 2;
            towerHeightSpawn += _selectedTower.transform.position.y;
            Vector3 towerSpawn = new Vector3(_selectedTower.transform.position.x, towerHeightSpawn, _selectedTower.transform.position.z);
            Instantiate(tower, towerSpawn, tower.transform.rotation, _selectedTower.transform);
            _startTimer = true;
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
            float towerHeightSpawn = NewTower.transform.localScale.y * 2;
            towerHeightSpawn += _selectedTower.transform.position.y;
            Vector3 towerSpawn = new Vector3(_selectedTower.transform.position.x, towerHeightSpawn, _selectedTower.transform.position.z);
            Instantiate(NewTower, towerSpawn, NewTower.transform.rotation, _selectedTower.transform);
            _startTimer = true;
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
