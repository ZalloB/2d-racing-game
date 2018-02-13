using System;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelManager : MonoBehaviour {

    public GameObject pauseMenu;
    public float actualTime = 0;
    public bool isStarted;
    public Text textTime;

    // Use this for initialization
    void Start () {
        isStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
        CheckPauseGame();
        if(isStarted)
        UpdateTimeUI();
	}

    void CheckPauseGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !pauseMenu.activeSelf)
        {
            //SoundManager.instance.RandomizeSfx(pause);
            //SoundManager.instance.musicSource.Pause();
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void UpdateTimeUI()
    {
        actualTime += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(actualTime);
        if (timeSpan.Hours > 0)
            textTime.text = string.Format("TIME: {0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        else
            textTime.text = string.Format("TIME: {1:D2}:{2:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }
}
