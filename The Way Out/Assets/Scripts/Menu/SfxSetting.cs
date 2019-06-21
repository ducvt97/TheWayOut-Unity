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
        var menu = GameObject.FindGameObjectWithTag("GameController").GetComponent<Menu>();
        slider.value = menu.savedData.settingData.SFX;
        audioMixer.SetFloat("SFX", slider.value);
    }

    public void OnValueChange()
    {
        if (slider != null)
            audioMixer.SetFloat("SFX", slider.value);
    }
}
