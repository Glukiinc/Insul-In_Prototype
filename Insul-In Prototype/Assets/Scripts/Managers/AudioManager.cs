using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    int trackNum;
    AudioSource audioSource;

    public bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StopAudio(int track)
    {
        if (audioSource.isPlaying && !audioSource.clip.ToString().Contains(track.ToString()))
        {
            audioSource.Stop();
        }
    }

    public void PlayAudio(int track)
    {
        string fileName = "Intro";

        if (track > 0 && track < 14)
        {
            fileName += track.ToString();
        }
        
        AudioClip audioClip = Resources.Load<AudioClip>("Sounds/" + fileName);

        StopAudio(track);

        if (track > 1 && !audioSource.clip.name.Contains(audioClip.name))
        {
            completed = false;
        }

        if (audioSource.isPlaying == false && !completed)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        if (audioSource.clip.length - audioSource.time <= 1)
        {
            completed = true;
        }
    }
}
