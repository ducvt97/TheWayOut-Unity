using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundControl : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        var _audioSource = this.GetComponent<AudioSource>();
        if (_audioSource != null)
            audioSource = _audioSource;
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
