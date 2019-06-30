using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedItemShop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
        if (save.savedData._savedData.level >= 4)
        {
            if (save.savedData._savedData.speedUp)
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
            stateText.text = "Pass level 4 to unlock";
            stateText.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
