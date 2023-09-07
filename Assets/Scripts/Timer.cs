using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 30;
    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0) 
        {
            timeValue -= Time.deltaTime;
        }
        else 
        {
            timeValue = 0;
        }

        displayTime(timeValue);
    }

    void displayTime(float time)
    {
        if (time <= 0) 
        {
            time = 0;
            SceneManager.LoadScene("loss");
        }

        float min = Mathf.FloorToInt(time/60);
        float sec = Mathf.FloorToInt(time%60);

        timeText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
