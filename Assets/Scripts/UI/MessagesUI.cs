using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagesUI : MonoBehaviour
{
    [SerializeField] protected Text _text;
    [SerializeField] protected float _disableTime = 3;

    [SerializeField] protected MessageManager _messageManager;

    private void Awake()
    {
        DisableMessage();
    }

    public virtual void EnableMessageUI(string message)
    {
        if (_messageManager._messageON != true)
        {
            _messageManager.MessageON();
            _text.text = message;

            CancelInvoke();
            Invoke("DisableMessage", _disableTime);
        }
        else if (_disableTime != 0)
        {
            _messageManager.MessageON();
            _text.text = message;

            CancelInvoke();
            Invoke("DisableMessage", _disableTime);
        }
    }

    public virtual void DisableMessage()
    {
        _messageManager.MessageOFF();
        _text.text = " ";
    }
}