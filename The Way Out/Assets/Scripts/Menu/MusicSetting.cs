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
        var menu = GameObject.FindGameObjectWithTag("GameController").GetComponent<Menu>();
        slider.value = menu.savedData._savedData.music;
        audioMixer.SetFloat("Music", slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChange()
    {
        audioMixer.SetFloat("Music", slider.value); 
    }
}
