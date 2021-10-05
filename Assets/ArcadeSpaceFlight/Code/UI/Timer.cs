using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int baseMinutes = 10;
    private int baseSeconds = 60;
    public float timeRemaing = 0;
    private bool timeStillRunning = true;
    public Text timeText;
    public Text TargetsRemaining;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaing = (float)(baseSeconds * baseMinutes); 
        //Debug.Log(spawner.name + " has " + spawner.transform.childCount + " children");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStillRunning)
        {
            if (timeRemaing > 0)
            {
                timeRemaing -= Time.deltaTime;
            }
            else
            {
                timeRemaing = 0;
                SceneManager.LoadScene("EndGame");
                timeStillRunning = false;
            }
        }
        DisplayTime(timeRemaing);
        DisplayTargetsRemaining();
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DisplayTargetsRemaining()
    {
        TargetsRemaining.text = string.Format("{0}", spawner.transform.childCount);
    }
}
