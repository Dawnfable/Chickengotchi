using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSettings : MonoBehaviour
{
    public static PlayerSettings instance;

    private const string MUSIC_KEY = "MusicEnabled";
    private const string MUSIC_VOLUME = "MusicVolume";
    [SerializeField]
    private Toggle musicToggle;
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private Slider musicVolumeSlider;
    private void Awake()
    {
        instance = this;
        LoadMusicEnabledSetting();
        LoadMusicVolumeSetting();
    }

    private void LoadMusicVolumeSetting()
    {
        if (!PlayerPrefs.HasKey(MUSIC_VOLUME))
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME, 1);
            musicSource.volume = 1;
            musicVolumeSlider.value = 1;
        }
        else
        {
            musicSource.volume = PlayerPrefs.GetFloat(MUSIC_VOLUME);
            musicVolumeSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME);
        }
    }

    private void LoadMusicEnabledSetting()
    {
        if (!PlayerPrefs.HasKey(MUSIC_KEY))
        {
            PlayerPrefs.SetInt(MUSIC_KEY, 1);
            musicToggle.isOn = true;
            musicSource.enabled = true;
            PlayerPrefs.Save();
        }
        else
        {
            if (PlayerPrefs.GetInt(MUSIC_KEY) == 0)
            {
                musicToggle.isOn = false;
                musicSource.enabled = false;
            }
            else
            {
                musicToggle.isOn = true;
                musicSource.enabled = true;
            }
        }
    }

    public void SetVolume()
    {
        musicSource.volume = musicVolumeSlider.value;
        PlayerPrefs.SetFloat(MUSIC_VOLUME, musicVolumeSlider.value);
        PlayerPrefs.Save();
    }

    public void ToggleMusic()
    {
        if (musicToggle.isOn)
        {
            PlayerPrefs.SetInt(MUSIC_KEY, 1);
            musicSource.enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt(MUSIC_KEY, 0);
            musicSource.enabled = false;
        }
        PlayerPrefs.Save();
    }
}
