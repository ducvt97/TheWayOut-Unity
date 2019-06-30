using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject[] objectListToBeActive;
    public int message;
    public string sceneName;

    public void WinStage()
    {
        var balls = GameObject.FindGameObjectWithTag("GameController").GetComponent<gamePlayCanvas>().ballsTotal;
        var save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
        save.savedData._savedData.diamond += balls;
        if ((SceneManager.GetActiveScene().buildIndex - 3) >= save.savedData._savedData.level)
            save.savedData._savedData.level += 1;
        save.savedData.OverwriteDataFile();
        SceneManager.LoadScene("StageSelect");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void NewGame()
    {
        var save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
        save.savedData.ResetProgress();
        LoadScene();
    }

    public void MenuItem()
    {
        PlaySound();
        TurnToNormalState();
        var mainMenu = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<MainMenu>();
        if (mainMenu != null)
        {
            mainMenu.MenuItemEvent(message);
        }
        
    }

    public void BuyItem()
    {
        PlaySound();
        var shop = GameObject.FindGameObjectWithTag("ShopMenu").GetComponent<ShopMenu>();
        if (shop != null)
            shop.BuyItem(message);
    }
    
    public void Back()
    {
        PlaySound();
        TurnToNormalState();
        int length = objectListToBeActive.Length;
        if (length > 0)
        {
            for (int i = 0; i < length; i++)
            {
                objectListToBeActive[i].SetActive(true);
            }
        }
        transform.parent.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ScrollLeft()
    {
        PlaySound();
        var scrollRect = GameObject.FindGameObjectWithTag("ScrollField").GetComponent<ScrollRect>();
        if (scrollRect != null)
            scrollRect.horizontalNormalizedPosition -= 0.1f;
    }
    public void ScrollRight()
    {
        PlaySound();
        var scrollRect = GameObject.FindGameObjectWithTag("ScrollField").GetComponent<ScrollRect>();
        if (scrollRect != null)
            scrollRect.horizontalNormalizedPosition += 0.1f;
    }

    public void StageSelect()
    {
        PlaySound();
        var stageSelectMenu = GameObject.FindGameObjectWithTag("StageSelectMenu").GetComponent<StageSelectMenu>();

        if(stageSelectMenu.stageSelect > 0)
        {
            var deselect = transform.parent.GetChild(stageSelectMenu.stageSelect - 1);
            deselect.Find("SelectFrame").gameObject.SetActive(false);
        }

        transform.Find("SelectFrame").gameObject.SetActive(true);
        
        stageSelectMenu.StageSelect(message);
    }

    public void StageLoad()
    {
        PlaySound();
        var stageSelectMenu = GameObject.FindGameObjectWithTag("StageSelectMenu").GetComponent<StageSelectMenu>();
        if (stageSelectMenu != null)
            stageSelectMenu.StageLoad();
    }

    public void ContinuePlay()
    {
        Time.timeScale = 1f;
        Back();
    }

    public void ActiveObject()
    {
        int length = objectListToBeActive.Length;
        if (length > 0)
        {
            for (int i = 0; i < length; i++)
            {
                objectListToBeActive[i].SetActive(true);
            }
        }
    }

    private void PlaySound()
    {
        var sound = this.GetComponent<AudioSource>();
        if (sound != null && sound.clip != null)
            sound.Play();
    }

    private void TurnToNormalState()
    {
        var anim = this.GetComponent<Animator>();
        if (anim != null)
            anim.SetTrigger("Normal");
    }
}
