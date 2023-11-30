using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{

    public static AudioManager audioManager;

    [SerializeField] private AudioSource soundObject;

    private void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;
        }
    }

    public void PlayAudio(AudioClip clip, Transform spawn, float volume)
    {
        AudioSource audioSource = Instantiate(soundObject, spawn.position, Quaternion.identity);

        audioSource.clip = clip;
        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
