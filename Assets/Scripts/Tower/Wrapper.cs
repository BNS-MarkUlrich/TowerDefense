using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    private List<LaserTurret> components = new List<LaserTurret>();

    private void Awake()
    {
        components.AddRange(GetComponents<LaserTurret>());
        components.AddRange(GetComponentsInChildren<LaserTurret>());

        foreach (LaserTurret tow in components)
        {
            //Debug.Log(tow.name);
            //tow.enabled = false;
        }
    }

    public void ToggleComponents()
    {
        foreach (LaserTurret mono in components)
        {
            //Debug.Log(mono.name);
            mono.enabled = !mono.enabled;
        }
    }
}
