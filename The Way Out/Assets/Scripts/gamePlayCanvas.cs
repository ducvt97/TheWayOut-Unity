using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class gamePlayCanvas : MonoBehaviour
{
    public static gamePlayCanvas instance;
    public Monster[] monsters;
    public Text txtBalls;
    public GameObject skill;
    public GameObject pauseMenu;
    public string ballsString;
    public int ballsTotal = 4;

    private int ballsFound = 0;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        updateCanvas();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }
    public void updateCanvas()
    {
        ballsString = "Balls " + ballsFound.ToString() + "/" + ballsTotal.ToString();
        txtBalls.text = ballsString;
        var save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
        if (save.savedData._savedData.speedUp)
            skill.SetActive(true);
    }

    public void findBall()
    {
        ballsFound++;
        updateCanvas();

        //win//
        if (ballsFound >= ballsTotal)
        {
            for (int n = 0; n < monsters.GetLength(0); n++)
            {
                monsters[n].death();
            }
        }
    }
}
