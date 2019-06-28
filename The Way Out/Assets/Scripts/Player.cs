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
            Destroy(other.gameObject);
            gamePlayCanvas.instance.findBall();
        }
        else if (other.CompareTag("BallRed"))
        {
            Destroy(other.gameObject);
            gamePlayCanvas.instance.findBall();
            IconMinimapMonster.SetActive(true);
            Invoke("hideInconMinimapMonster", 30f);
        }
        else if (other.CompareTag("BallYellow"))
        {
            Destroy(other.gameObject);
            gamePlayCanvas.instance.findBall();
            //pauseMonster();
            other.transform.parent.GetComponent<Monster>().speedZero();
            //Invoke("continueMonster", 15f);
        }
    }

    void hideInconMinimapMonster()
    {
        IconMinimapMonster.SetActive(false);
    }

    //void pauseMonster()
    //{
    //    NavMeshAgent nav = monster.GetComponent<Monster>().getNav();
    //    Animator anim = monster.GetComponent<Monster>().getAnim();
    //    nav.speed = 0f;
    //    anim.speed = 0f;
    //}

    //void continueMonster()
    //{
    //    NavMeshAgent nav = monster.GetComponent<Monster>().getNav();
    //    Animator anim = monster.GetComponent<Monster>().getAnim();
    //    nav.speed = 1.2f;
    //    anim.speed = 1.2f;
    //}

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
