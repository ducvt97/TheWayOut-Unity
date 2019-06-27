using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool alive = true;

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
}
