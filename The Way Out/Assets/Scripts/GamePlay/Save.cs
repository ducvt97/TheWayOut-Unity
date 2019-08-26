using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Save : MonoBehaviour
{
    public SavedData savedData;
    public AudioMixer audioMixer;
    public TextAsset savedDataFile;

    void Awake()
    {
        savedData = new SavedData();
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("Music", savedData._savedData.music);
        audioMixer.SetFloat("SFX", savedData._savedData.sfx);
    }
    
}
