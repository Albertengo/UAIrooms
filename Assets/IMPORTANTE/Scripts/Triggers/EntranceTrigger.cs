using UnityEngine;

public class EntrangeTrigger : MonoBehaviour
{

    //public AudioClip blockedSound;
    public float interactionDistance = 2f;

    //private AudioSource audioSource;
    private Transform player;
    private bool isPlayerNear = false;
    private bool playerInside = false;

    void Start()
    {
        //audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.playOnAwake = false;

        player = GameObject.FindGameObjectWithTag("Player")?.transform;


    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.F))
        {
            PlayBlockedSound();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    void PlayBlockedSound()
    {
        //if (blockedSound != null)
        //{
            //audioSource.clip = blockedSound;
            //audioSource.Play();
            Debug.Log("la puerta esta bloqueada");
        }
    }

