using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingMenu, moreInfo, newGamePopup, quitPopup;
    private Save save;

    // Start is called before the first frame update
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
        if (save.savedData._savedData.isNew)
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
                SceneManager.LoadScene("StageSelect");
                break;
            case 1:
                if(!save.savedData._savedData.isNew)
                    newGamePopup.SetActive(true);
                else
                {
                    save.savedData._savedData.isNew = false;
                    save.savedData.OverwriteDataFile();
                    SceneManager.LoadScene("StageSelect");
                }
                break;
            case 2:
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
