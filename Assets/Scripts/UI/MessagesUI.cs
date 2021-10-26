using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagesUI : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _disableTime = 3;

    [SerializeField] private MessageManager _messageManager;

    void Awake()
    {
        DisableMessage();
    }

    public void EnableMessageUI(string message)
    {
        if (_messageManager._messageON != true)
        {
            _messageManager.MessageON();
            _text.text = message;
            
            //gameObject.SetActive(true);

            CancelInvoke();
            Invoke("DisableMessage", _disableTime);
        }
        else
        {
            DisableMessage();
        }
    }

    private void DisableMessage()
    {
        _messageManager.MessageOFF();
        _text.text = " ";
        //gameObject.SetActive(false);
    }
}