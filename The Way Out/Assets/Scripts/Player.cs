using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public bool alive = true;
    public int ourHealth;
    public int maxhealth = 2;
    public GameObject IconMinimapMonster;
    public AudioSource touchBall;

    private Vector3 startPos;
    private Quaternion startRotation;
    void Start()
    {
        ourHealth = maxhealth;
        startPos = transform.position;
        startRotation = transform.rotation;
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
            IconMinimapMonster.SetActive(true);
            Invoke("hideInconMinimapMonster", 60f);
        }
        else if (other.CompareTag("BallYellow"))
        {
            touchBall.Play();
            Monster.instance.speedZero();
            Invoke("activeMonster", 30f);
            Destroy(other.gameObject);
            gamePlayCanvas.instance.findBall();
            //pauseMonster();
        }
    }

    void hideInconMinimapMonster()
    {
        IconMinimapMonster.SetActive(false);
    }

    void activeMonster()
    {
        Monster.instance.speedNormal();
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
