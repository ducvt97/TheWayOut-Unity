using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject settingMenu, stageSelectMenu, moreInfo, logo, newGamePopup, quitPopup;
    private Menu menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("GameController").GetComponent<Menu>();
        if(menu.savedData.playerData.IsNew)
            transform.GetChild(0).transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuItemEvent(int message)
    {
        switch (message)
        {
            case 0:
                newGamePopup.SetActive(false);
                if (stageSelectMenu != null)
                    stageSelectMenu.SetActive(true);
                logo.SetActive(false);
                transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 1:
                newGamePopup.SetActive(true);
                break;
            case 2:
                //var setting = GameObject.FindGameObjectWithTag("SettingMenu");
                if (settingMenu != null)
                    settingMenu.SetActive(true);
                break;
            case 3:
                moreInfo.SetActive(true);
                break;
            case 4:
                quitPopup.SetActive(true);
                break;
            default:
                break;
        }
    }
}
