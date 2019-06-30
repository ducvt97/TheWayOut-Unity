using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public static Boss instance;
    public GameObject player;
    public AudioClip[] footsounds;
    public Transform eyes;
    public AudioSource growl;
    public GameObject deathCam;
    public GameObject mainCam;
    public GameObject winPanel;
    public Transform camPos;
    public float speedHunt = 1.5f;

    private NavMeshAgent nav;
    private AudioSource sound;
    private Animator anim;
    private string state = "idle";
    private bool alive = true;
    private float wait = 0f;
    private bool highAlert = false;
    private float alertness = 20f;
    private Vector3 startPosBoss;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        sound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.speed = speedHunt;
        nav.speed = speedHunt;
        startPosBoss = transform.position;
        growl.pitch = 1.2f;
        growl.Play();
    }

    public void footstep(int _num)
    {
        sound.clip = footsounds[_num];
        sound.Play();
    }

    public void checkSight()
    {
        if (alive)
        {
            RaycastHit rayHit;
            if (Physics.Linecast(eyes.position, player.transform.position, out rayHit))
            {
                //print("hit " + rayHit.collider.gameObject.name);
                if (rayHit.collider.gameObject.name == "eyes")
                {
                        growl.pitch = 1.2f;
                        growl.Play();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.transform.position);

        if (nav.remainingDistance <= nav.stoppingDistance + 1f && !nav.pathPending)
        {
            if (player.GetComponent<Player>().alive)
            {
                //state = "kill";
                player.GetComponent<Player>().alive = false;
                player.GetComponent<ThirdPersonUserControl>().enabled = false;
                deathCam.SetActive(true);
                deathCam.transform.position = Camera.main.transform.position;
                deathCam.transform.rotation = Camera.main.transform.rotation;
                mainCam.SetActive(false);
                //Camera.main.gameObject.SetActive(false);
                growl.pitch = 0.7f;
                growl.Play();
                Invoke("reset", 1f);
            }


        }
    }

    //reset//
    void reset()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.GetComponent<Player>().alive = true;
        player.GetComponent<ThirdPersonUserControl>().enabled = true;
        //Camera.main.gameObject.SetActive(true); 
        mainCam.SetActive(true);
        deathCam.SetActive(false);
        player.GetComponent<Player>().ourHealth -= 1;
        player.GetComponent<Player>().transform.position = player.GetComponent<Player>().getStartPosPlayer();
        player.GetComponent<Player>().transform.rotation = player.GetComponent<Player>().getStartRotPlayer();
        transform.position = startPosBoss;
        anim.speed = 1.2f;
        nav.speed = 1.2f;
        //state = "idle";
    }

    //die//
    public void death()
    {
        //anim.SetTrigger("dead");
        anim.speed = 1f;
        alive = false;
        nav.Stop();
        winPanel.SetActive(true);
    }

    public void speedZero()
    {
        anim.speed = 0f;
        nav.speed = 0f;
        alive = false;
        nav.Stop();
    }

    public void speedNormal()
    {
        anim.speed = 1.2f;
        nav.speed = 1.2f;
        alive = true;
        nav.Resume();
    }
}
