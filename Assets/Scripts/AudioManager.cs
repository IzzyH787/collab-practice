using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource audioSource;

    public AudioClip BGM;
    public AudioClip Hoop;
    public AudioClip Leveldone;

    private void Start()
    {
        BGMSource.clip = BGM;
        BGMSource.Play();
    }

    public void PlayAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
