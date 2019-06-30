using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SfxSetting : MonoBehaviour
{
    public AudioMixer audioMixer;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponent<Slider>();
        var save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
        slider.value = save.savedData._savedData.sfx;
    }

    public void OnValueChange()
    {
        if (slider != null)
        {
            audioMixer.SetFloat("SFX", slider.value);
            var save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
            save.savedData._savedData.sfx = slider.value;
            save.savedData.OverwriteDataFile();
        }
            
    }
}
