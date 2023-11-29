using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSounds : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField] float volume = 0.5f;

    [SerializeField] AudioClip zombieSound1;
    float zombieSound1Length;

    bool audioPlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        zombieSound1Length = zombieSound1.length;
    }
    private void Update()
    {
        PlayZombieSounds();
    }

    private void PlayZombieSounds()
    {
        if (!audioPlaying)
        {
            AudioManager.audioManager.PlayAudio(zombieSound1, transform, volume);
            audioPlaying = true;

            StartCoroutine(SoundTimer(zombieSound1Length));
        }
    }

    private IEnumerator SoundTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        audioPlaying = false;
    }
}
