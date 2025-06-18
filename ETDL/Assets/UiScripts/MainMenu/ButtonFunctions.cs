using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    [Header("Screens")]
    public GameObject[] menuScreens;

    [Header("Buttons")]
    public Button[] buttons;

    [Header("Audio")]
    public AudioSource menuAudioSource;
    public AudioClip clickAudio;

    [Header("Animation")]
    public PlayableDirector nexusAnim;
    public Animator doorAnim;

    [Header("Timer")]
    public Timer timer;

    public void SettingsScreenActive()
    {
        menuScreens[0].SetActive(true);
        menuScreens[1].SetActive(false);

        menuAudioSource.clip = clickAudio;
        menuAudioSource.Play();
    }
    public void CreditsScreenActive()
    {
        menuScreens[1].SetActive(true);
        menuScreens[0].SetActive(false);

        menuAudioSource.clip = clickAudio;
        menuAudioSource.Play();
    }
    public void PlayGame()
    {
        menuAudioSource.clip = clickAudio;
        menuAudioSource.Play();

        foreach(Button button in buttons)
        {
            button.interactable = false;
        }

        menuScreens[0].SetActive(false);
        menuScreens[1].SetActive(false);
        menuScreens[2].SetActive(true);

        nexusAnim.Play();

        StartCoroutine(StartGameAfterAnim((float)nexusAnim.duration));
    }
    public IEnumerator StartGameAfterAnim(float time)
    {
        yield return new WaitForSeconds(time);
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
        buttons[0].interactable = false;

        doorAnim.SetInteger("door", 1);

        timer.startTimer = true;

        //play door animation
    }
}
