using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public float levelTimer;

    public Text timeText;
    [SerializeField] private Text _message;
    [SerializeField] private Text _messageExplanation;

    private void Update()
    {
        bool startLevel = FindObjectOfType<WaveHandler>()._startLevel;
        if (startLevel == true)
        {
            levelTimer += Time.deltaTime;

            float minutes = Mathf.FloorToInt(levelTimer / 60);
            float seconds = Mathf.FloorToInt(levelTimer % 60);
            float milliSeconds = (levelTimer % 1) * 1000;

            timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);

            _message.text = ("");
            _messageExplanation.text = ("");
        }
    }
}
