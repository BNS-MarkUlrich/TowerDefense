using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOverrideUI : MonoBehaviour
{
    [SerializeField] private MessagesUI _buildOverrideUI;

    public void CantBuild()
    {
        _buildOverrideUI.EnableMessageUI("You cannot build on this tile! (sometimes)");
    }
}
