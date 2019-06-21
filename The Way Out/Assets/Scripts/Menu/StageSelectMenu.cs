using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectMenu : MonoBehaviour
{
    public Button[] stageList;
    public Button buttonPlay;
    private Menu menu;
    public int stageSelect = 0;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("GameController").GetComponent<Menu>();
        ProgressDataLoad();
    }

    // Update is called once per frame
    void Update()
    {
        if(!buttonPlay.IsActive())
        {
            if (stageSelect > 0)
                transform.Find("ButtonPlay").gameObject.SetActive(true);
        }
    }

    public void StageSelect(int level)
    {
        stageSelect = level;
    }

    public void StageLoad()
    {
        Debug.Log(stageSelect);
        //SceneManager.LoadScene("Stage" + stageSelect.ToString());
    }

    public void ProgressDataLoad()
    {
        int curLevel = menu.savedData.playerData.Level + 1;
        for (int i = 0; i < curLevel; i++)
        {
            stageList[i].gameObject.transform.Find("Lock").gameObject.SetActive(false);
            stageList[i].interactable = true;
        }
    }
}
