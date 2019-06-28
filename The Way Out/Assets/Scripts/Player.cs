using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool alive = true;
    public int ourHealth;
    public int maxhealth = 2;

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
        if (other.gameObject.name == "eyes")
        {
            other.transform.parent.GetComponent<Monster>().checkSight();
        }
        else if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            gamePlayCanvas.instance.findBall();
        }
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
