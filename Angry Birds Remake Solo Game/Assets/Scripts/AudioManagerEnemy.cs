using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerEnemy : MonoBehaviour
{
    public static AudioManagerEnemy instance = null;
    public AudioSource audioSource;

    [Header("Pitch")]
    public float minPitchValue;
    public float maxPitchValue;
    [Header("Volume")]
    public float minVolumeValue;
    public float maxVolumeValue;

    private void Awake()
    {
        if (instance == null) //if it doesnt exist
        {
            instance = this; //instantiation
        }
        else if (instance != this) //if instance exists but it's not this exact one
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void PlayClip(AudioClip clip)
    {
        RandomizeSound();
        audioSource.PlayOneShot(clip);
    }

    private void RandomizeSound()
    {
        //volume and pitch
        audioSource.pitch = Random.Range(minPitchValue, maxPitchValue);
        audioSource.volume = Random.Range(minVolumeValue, maxVolumeValue);
    }
}
