using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource audioSource;

    public AudioClip BGM;
    public AudioClip Hoop;
    public AudioClip Leveldone;
    public AudioClip LevelCompletedBGM;

    public Slider volumeSlider;

    float sliderValue;

    private void Start()
    {
        BGMSource.clip = BGM;
        BGMSource.Play();
        sliderValue = 100;

        BGMSource.volume = PlayerPrefs.GetFloat("BGMSource", 0.5f);
        BGMSource.loop = true; //Allow the BGM to loop
    }

    private void Update()
    {
        sliderValue = volumeSlider.value;
        volumeSlider.value = PlayerPrefs.GetFloat("BGMSource");
    }

    public void ChangeBGM()
    {
        BGMSource.clip = LevelCompletedBGM;
        BGMSource.Play();
    }

    public void PlayAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void OnVolumeChange(float volume)
    {
        volume = volumeSlider.value;

        BGMSource.volume = volume;
        audioSource.volume = volume;

        PlayerPrefs.SetFloat("BGMSource", volume);
        PlayerPrefs.SetFloat("audioSource", volume);
        PlayerPrefs.Save();

        Debug.Log(volume);
    }
}
