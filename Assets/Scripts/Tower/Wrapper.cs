using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    private List<BaseTower> components = new List<BaseTower>();

    private void Awake()
    {
        components.AddRange(GetComponents<BaseTower>());
        components.AddRange(GetComponentsInChildren<BaseTower>());

        foreach (BaseTower tow in components)
        {
            //Debug.Log(tow.name);
            //tow.enabled = false;
        }
    }

    public void ToggleComponents()
    {
        foreach (BaseTower mono in components)
        {
            //Debug.Log(mono.name);
            mono.enabled = !mono.enabled;
        }
    }
}
