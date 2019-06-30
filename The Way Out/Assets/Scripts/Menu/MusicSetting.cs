using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSetting : MonoBehaviour
{
    public AudioMixer audioMixer;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponent<Slider>();
        var save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
        slider.value = save.savedData._savedData.music;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChange()
    {
        audioMixer.SetFloat("Music", slider.value);
        var save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
        save.savedData._savedData.music = slider.value;
        save.savedData.OverwriteDataFile();
    }
}
