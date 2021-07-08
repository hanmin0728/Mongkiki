using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip audioclip { get; private set; }

    [SerializeField]
    private float controlVolume;

    public AudioSource audioSource;

    public Slider slider;
 
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public void ChangeVolume()
    {
        controlVolume = slider.value;
        audioSource.volume = controlVolume;
    }

}
