using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagesUI : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _disableTime = 3;

    void Awake()
    {
        DisableMessage();
    }

    public void EnableMessageUI(string message)
    {
        _text.text = message;
        gameObject.SetActive(true);

        CancelInvoke();
        Invoke("DisableMessage", _disableTime);
    }

    private void DisableMessage()
    {
        gameObject.SetActive(false);
    }


    /*
    private void Update()
    {
        _notEnoughPoints = FindObjectOfType<TowerBuilder>()._limitedPoints;
        _popUpTimer -= Time.deltaTime;
    }

    public void NotEnoughPointsUI(float currentPoints)
    {
        if (_notEnoughPoints == true)
        {
            _popUpTimer -= Time.deltaTime;
            if (_popUpTimer <= 0.0f)
            {
                _text.text = " ";
                print(_text.text);
                //gameObject.SetActive(false);
            }
        }
        else
        {
            //gameObject.SetActive(true);
            print(_text.text);
            _text.text = currentPoints + " is not enough points!";
        }
    }
    */
}