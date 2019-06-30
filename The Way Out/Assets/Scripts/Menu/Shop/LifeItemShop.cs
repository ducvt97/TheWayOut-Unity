using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeItemShop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
        if(save.savedData._savedData.level >= 2)
        {
            if(save.savedData._savedData.life == 3)
            {
                transform.GetChild(2).gameObject.SetActive(false);
                var stateText = transform.GetChild(3).GetComponent<Text>();
                stateText.text = "Unlocked";
                stateText.gameObject.SetActive(true);
            }
        }
        else
        {
            transform.GetChild(2).gameObject.SetActive(false);
            var stateText = transform.GetChild(3).GetComponent<Text>();
            stateText.text = "Pass level 2 to unlock";
            stateText.gameObject.SetActive(true);
        }
    }
}
