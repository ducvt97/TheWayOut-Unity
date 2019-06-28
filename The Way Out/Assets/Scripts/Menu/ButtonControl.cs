using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject[] objectListToBeActive;
    public int message;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void GoShopping()
    {
        PlaySound();
        if (objectListToBeActive.Length != 0)
            objectListToBeActive[0].SetActive(true);
    }

    private void PlaySound()
    {
        var sound = this.GetComponent<AudioSource>();
        if (sound != null)
            sound.Play();
    }

    private void TurnToNormalState()
    {
        var anim = this.GetComponent<Animator>();
        if (anim != null)
            anim.SetTrigger("Normal");
    }
}
