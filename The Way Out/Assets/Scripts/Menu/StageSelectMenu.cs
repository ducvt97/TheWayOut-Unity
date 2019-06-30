using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectMenu : MonoBehaviour
{
    public Button[] stageList;
    public Button buttonPlay;
    private Save save;
    public int stageSelect = 0;

    // Start is called before the first frame update
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
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
        int curLevel = save.savedData._savedData.level + 1;
        for (int i = 0; i < curLevel; i++)
        {
            stageList[i].gameObject.transform.Find("Lock").gameObject.SetActive(false);
            stageList[i].interactable = true;
        }
    }
}
