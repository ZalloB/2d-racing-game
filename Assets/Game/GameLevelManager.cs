using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelManager : MonoBehaviour {

    public GameObject pauseMenu;
    public float actualTime = 0;
    public bool isStarted;
    public Text textTime;
    public Text countdown;

    public GameObject panelCountdown;

    public AudioClip[] startClips;
    public AudioClip pause;

    public int maxCheckpoints = 5;
    private int generalCountChecks = 0;
    public int[] checkpointsNumbers;

    public GameObject winingPanel;

    public int goldTime = 10;
    public Sprite goldMedal;
    public int silverTime = 14;
    public Sprite silverMedal;
    public int bronzeTime = 16;
    public Sprite bronzeMedal;

    public Image medalImage;
    public Text timeWinText;

    // Use this for initialization
    void Start () {
        checkpointsNumbers = new int[maxCheckpoints];

        isStarted = false;
        StartCoroutine("StartGame");
    }
	
	// Update is called once per frame
	void Update () {
        CheckPauseGame();
        if(isStarted)
        UpdateTimeUI();
	}

    IEnumerator StartGame()
    {
        int count = 4;
      foreach(AudioClip clip in startClips)
        {
            //TODO show numbers
            if (count == 4)
            {
                countdown.text = "READY";  
            }else if (count == 0)
            {
                countdown.text = "GO";
            }
            else
            {
                countdown.text = count.ToString();
            }
                   
            SoundManager.instance.RandomizeSfx(clip);
            yield return new WaitForSeconds(1f);
            count--;
        }

        panelCountdown.SetActive(false);
        isStarted = true;
    }

    void CheckWin()
    {
        bool isWin = true;
        for (int i=1; i <= maxCheckpoints; i++) {
            if(checkpointsNumbers[i - 1] != i)
            {
                isWin = !isWin;
                break;
            }
        }

        if (isWin)
        {
            Time.timeScale = 0;
            winingPanel.SetActive(true);
            //countdown.text = "Finish: ";
            TimeSpan timeSpan = TimeSpan.FromSeconds(actualTime);

            if (actualTime <= goldTime)
                medalImage.sprite = goldMedal;
            else if (actualTime <= silverTime && actualTime > goldTime)
                medalImage.sprite = silverMedal;
            else if(actualTime > silverTime)
                medalImage.sprite = bronzeMedal;

            if (timeSpan.Hours > 0)
                timeWinText.text = string.Format("TIME: {0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            else
                timeWinText.text = string.Format("TIME: {0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);


        }
        
            checkpointsNumbers = new int[maxCheckpoints];
            generalCountChecks = 0;

    }

    void AddCheckpoint(int number)
    {
        Debug.Log("Add checkpoint "+number+" at point "+ generalCountChecks);
        checkpointsNumbers[generalCountChecks] = number;
        generalCountChecks++;
    }

    void CheckPauseGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !pauseMenu.activeSelf)
        {

            SoundManager.instance.RandomizeSfx(pause);
            SoundManager.instance.musicSource.Pause();
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
            textTime.text = string.Format("TIME: {0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }
}
