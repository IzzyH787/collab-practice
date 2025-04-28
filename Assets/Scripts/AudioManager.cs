using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource specialSoundEffectSource;
    [SerializeField] AudioSource audioSource;

    public AudioClip BGM;
    public AudioClip Hoop;
    public AudioClip Leveldone;
    public AudioClip LevelCompletedBGM;
    public AudioClip SpecialSoundEffect;

    public Slider volumeSlider;

    float sliderValue;

    private void Start()
    {
        BGMSource.clip = BGM;
        BGMSource.Play();
        sliderValue = 100;
        specialSoundEffectSource.clip = SpecialSoundEffect;

        BGMSource.volume = PlayerPrefs.GetFloat("BGMSource", 0.5f);
        BGMSource.loop = true; //Allow the BGM to loop
        specialSoundEffectSource.loop = true;
    }
    
    private void Update()
    {
        sliderValue = volumeSlider.value;
        volumeSlider.value = PlayerPrefs.GetFloat("BGMSource");
        specialSoundEffectSource.volume = PlayerPrefs.GetFloat("BGMSource", 0.5f);
    }

    public void ChangeBGM()
    {
        BGMSource.clip = LevelCompletedBGM;
        BGMSource.Play();
    }

    public void PlaySoundEffectBGM()
    {
        specialSoundEffectSource.Play();
        specialSoundEffectSource.volume = PlayerPrefs.GetFloat("BGMSource", 0.5f);
        Debug.Log("Play");
    }

    public void StopSoundEffectBGM()
    {
        specialSoundEffectSource.Stop();
        Debug.Log("Stop");
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
