using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    [SerializeField] private string _text;

    public void LoadScene()
    {
        SceneManager.LoadScene(_text);
    }
}