using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsFunction : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer audioMixer;
    public TMP_Text masterPercentage;
    public TMP_Text musicPercentage;
    public TMP_Text sfxPercentage;
    public float currentMasterVolume;
    public float currentMusicVolume;
    public float currentSFXVolume;

    void Start()
    {
        currentMasterVolume = PlayerPrefs.GetFloat("MasterPref");
        currentMusicVolume = PlayerPrefs.GetFloat("MusicPref");
        currentSFXVolume = PlayerPrefs.GetFloat("SFXPref");

        SetMasterVolume(currentMasterVolume);
        SetMusicVolume(currentMusicVolume);
        SetSFXVolume(currentSFXVolume);
    }
    #region volume
    #region Master
    public void IncreaseMasterVolume()
    {
        if(currentMasterVolume < 100f)
        {
            currentMasterVolume += 10f;
            PlayerPrefs.SetFloat("MasterPref", currentMasterVolume);

            SetMasterVolume(currentMasterVolume);
        }
    }
    public void DecreaseMasterVolume()
    {
        if(currentMasterVolume > 0)
        {
            currentMasterVolume -= 10f;
            PlayerPrefs.SetFloat("MasterPref", currentMasterVolume);

            SetMasterVolume(currentMasterVolume);
        }
    }
    public void SetMasterVolume(float volume)
    {
        float dBValue = Mathf.Log10(Mathf.Clamp(volume / 100f, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("Master", dBValue);

        masterPercentage.text = currentMasterVolume.ToString() + "%";
    }
    #endregion
    #region Music
    public void IncreaseMusicVolume()
    {
        if(currentMusicVolume < 100f)
        {
            currentMusicVolume += 10f;
            PlayerPrefs.SetFloat("MusicPref", currentMusicVolume);

            SetMusicVolume(currentMusicVolume);
        }
    }
    public void DecreaseMusicVolume()
    {
        if(currentMusicVolume > 0f)
        {
            currentMusicVolume -= 10f;
            PlayerPrefs.SetFloat("MusicPref", currentMusicVolume);

            SetMusicVolume(currentMusicVolume);
        }
    }
    public void SetMusicVolume(float volume)
    {
        float dBValue = Mathf.Log10(Mathf.Clamp(volume / 100f, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("Music", dBValue);

        musicPercentage.text = currentMusicVolume.ToString() + "%";
    }
    #endregion
    #region SFX
    public void IncreaseSFXVolume()
    {
        if(currentSFXVolume < 100f)
        {
            currentSFXVolume += 10f;
            PlayerPrefs.SetFloat("SFXPref", currentSFXVolume);

            SetSFXVolume(currentSFXVolume);
        }
    }
    public void DecreaseSFXVolume()
    {
        if(currentSFXVolume > 0f)
        {
            currentSFXVolume -= 10f;
            PlayerPrefs.SetFloat("SFXPref", currentSFXVolume);

            SetSFXVolume(currentSFXVolume);
        }
    }
    public void SetSFXVolume(float volume)
    {
        float dBValue = Mathf.Log10(Mathf.Clamp(volume / 100f, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("SFX", dBValue);

        sfxPercentage.text = currentSFXVolume.ToString() + "%";
    }
    #endregion
    #endregion
}
