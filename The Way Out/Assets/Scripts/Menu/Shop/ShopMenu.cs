using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public GameObject ball, failedPopup;
    private Save save;

    // Start is called before the first frame update
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
        LoadData();
    }

    // Update is called once per frame

    public void LoadData()
    {
        ball.GetComponent<Text>().text = save.savedData._savedData.diamond.ToString();
    }

    public void BuyItem(int item)
    {
        switch (item)
        {
            case 0:
                if (save.savedData._savedData.diamond < 200)
                    failedPopup.SetActive(true);
                else
                {
                    save.savedData._savedData.diamond -= 200;
                    save.savedData._savedData.life = 3;
                    ball.GetComponent<Text>().text = save.savedData._savedData.diamond.ToString();

                    save.savedData.OverwriteDataFile();
                }
                break;
            case 1:
                if (save.savedData._savedData.diamond < 300)
                    failedPopup.SetActive(true);
                else
                {
                    save.savedData._savedData.diamond -= 400;
                    save.savedData._savedData.speedUp = true;
                    ball.GetComponent<Text>().text = save.savedData._savedData.diamond.ToString();

                    save.savedData.OverwriteDataFile();
                }
                break;
            default:
                break;
        }
    }
}
