using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    public GameObject keyObject;
    public UnityEvent onKeyPickup;
    public Item item;

    private bool isPlayerNear = false;
    public bool hasKey = false;

    public AudioClip pickupSound;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }


    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
        {
            onKeyPickup.Invoke(); // Evento al recoger llave
            audioSource.PlayOneShot(pickupSound);
            keyObject.SetActive(false); // Ocultar la llave
            InventoryManager.Instance.AddItem(item);
            hasKey = true;
            Debug.Log("Llave recogida.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }
}