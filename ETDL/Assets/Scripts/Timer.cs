using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] float timerDuration = 60.0f;
    [SerializeField] List<TMP_Text> timerTexts = new();

    public bool gameWon;
    public bool startTimer = false;

    float timeRemaining;
    bool hasTriggered = false;

    [Header("Audio")]
    public AudioSource loseSource;
    public AudioClip loseSound;

    void Start()
    {
        timeRemaining = timerDuration;
    }

    void Update()
    {
        if (!gameWon && startTimer)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else if (!hasTriggered)
            {
                timeRemaining = 0;
                hasTriggered = true;
                UpdateTimerDisplay(0);
                StartCoroutine(GameOver());
            }
        }

    }

    void UpdateTimerDisplay(float time)
    {
        if (time > 0)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);

            foreach (TMP_Text text in timerTexts)
            {
                text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            
        }
        else
        {
            foreach (TMP_Text text in timerTexts)
            {
                text.text = "Time's Up!";
            }
        }
    }

    IEnumerator GameOver()
    {
        loseSource.clip = loseSound;
        loseSource.Play();

        yield return new WaitForSeconds(8);

        SceneManager.LoadScene(0);
    }
}