using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private AudioClip buttonAudio;

    [SerializeField]
    private AudioClip playerDie;

    private AudioSource audioSource;

    //public AudioSource[] audioSources;
    //public AudioClip audioclip { get; private set; }

    // public float controlVolume;

    //public AudioSource audioSource;

    //public Slider slider;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            
        }
    }

    //private void Start()
    //{
    //    foreach (AudioSource audio in audioSources)
    //    {
    //        audio.volume = controlVolume;
    //    }
    //}

    //public void ChangeVolume()
    //{
    //    controlVolume = slider.value;

    //    foreach (AudioSource audio in audioSources)
    //    {
    //        audio.volume = controlVolume;
    //    }
    //}

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ButtonSound()
    {
        audioSource.PlayOneShot(buttonAudio);
    }
}
