using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] public float levelTimer;

    public Text timeText;

    private void Update()
    {
        levelTimer += Time.deltaTime;

        float minutes = Mathf.FloorToInt(levelTimer / 60);
        float seconds = Mathf.FloorToInt(levelTimer % 60);
        float milliSeconds = (levelTimer % 1) * 1000;

        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
