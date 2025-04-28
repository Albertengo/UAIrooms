using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    [SerializeField] Slider sanitySlider;
    [SerializeField] float max;
    [SerializeField] float min;

    private bool reduceSanity = false;
    public PlayerMovement playerMovement;



    private void Start()
    {
        SetSanitySliderValues();
        playerMovement = GetComponent<PlayerMovement>();
    }


    private void Update()
    {
        if (reduceSanity)
        {
            sanitySlider.value -= Time.deltaTime;
            playerMovement.Speed = Mathf.Max(2f, playerMovement.Speed - Time.deltaTime * 0.5f);

            if (sanitySlider.value == 0)
                GameManager.instance.GameOver();
        }
        else
        {
            sanitySlider.value += Time.deltaTime;
            playerMovement.Speed = Mathf.Min(10, playerMovement.Speed + Time.deltaTime); //aumenta el valor de speed y hace que no se pase de 10
        }
    }

    private void SetSanitySliderValues()
    {
        sanitySlider.value = max;
        sanitySlider.maxValue = max;
        sanitySlider.minValue = min;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sanity Zone"))
            reduceSanity = true;
    }

    private void OnTriggerExit(Collider other)
    {
        reduceSanity = false;
    }
}
