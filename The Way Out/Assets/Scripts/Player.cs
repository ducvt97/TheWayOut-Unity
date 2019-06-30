using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public bool alive = true;
    public int ourHealth;
    //public int maxhealth = 3;
    public GameObject[] IconMinimapMonster;
    public Monster[] monsters;
    public AudioSource touchBall;
    public GameObject Heart1;
    public GameObject Heart2;

    private Vector3 startPos;
    private Quaternion startRotation;
    void Start()
    {
        //ourHealth = maxhealth;
        startPos = transform.position;
        startRotation = transform.rotation;
        var save = GameObject.FindGameObjectWithTag("SavedData").GetComponent<Save>();
        ourHealth = save.savedData._savedData.life;
        if (ourHealth == 2)
            Heart1.SetActive(true);
        else if(ourHealth == 3)
            Heart2.SetActive(true);
    }

    void Update()
    {
        //print("ourHealth: " + ourHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        //print("Ball: " + other.gameObject.name);
        if (other.gameObject.name == "eyes")
        {
            other.transform.parent.GetComponent<Monster>().checkSight();
        }
        else if (other.CompareTag("Ball"))
        {
            touchBall.Play();
            Destroy(other.gameObject);
            gamePlayCanvas.instance.findBall();
        }
        else if (other.CompareTag("BallRed"))
        {
            touchBall.Play();
            Destroy(other.gameObject);
            gamePlayCanvas.instance.findBall();
            for (int n = 0; n < IconMinimapMonster.GetLength(0); n++)
            {
                IconMinimapMonster[n].SetActive(true);
            }
            Invoke("hideInconMinimapMonster", 60f);
        }
        else if (other.CompareTag("BallYellow"))
        {
            touchBall.Play();
            for (int n = 0; n < monsters.GetLength(0); n++)
            {
                monsters[n].speedZero();
            }
            //Monster.instance.speedZero();
            Invoke("activeMonster", 30f);
            Destroy(other.gameObject);
            gamePlayCanvas.instance.findBall();
            //pauseMonster();
        }
    }

    void hideInconMinimapMonster()
    {
        for (int n = 0; n < IconMinimapMonster.GetLength(0); n++)
        {
            IconMinimapMonster[n].SetActive(false);
        }
    }

    void activeMonster()
    {
        for (int n = 0; n < monsters.GetLength(0); n++)
        {
            monsters[n].speedNormal();
        }
        //Monster.instance.speedNormal();
    }

    public void bleed()
    {
        ourHealth = ourHealth - 1;
        print("ourHealth: " + ourHealth);
    }

    public Vector3 getStartPosPlayer()
    {
        return startPos;
    }

    public Quaternion getStartRotPlayer()
    {
        return startRotation;
    }
}
