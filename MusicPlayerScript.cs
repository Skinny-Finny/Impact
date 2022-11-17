using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    [SerializeField]
    public AudioSource AudioSource;

    private float musicVolume = 0.5f;


    void Start()
    {
        AudioSource.Play();
    }

    void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void UpdateVolume( float volume)
    {
        musicVolume = volume;
    }
}