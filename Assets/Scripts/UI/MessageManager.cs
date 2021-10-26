using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public bool _messageON;

    public bool MessageON()
    {
        return _messageON = true;
    }

    public bool MessageOFF()
    {
        return _messageON = false;
    }
}