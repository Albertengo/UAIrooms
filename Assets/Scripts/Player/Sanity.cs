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



    private void Start()
    {
        SetSanitySliderValues();
    }


    private void Update()
    {
        if (reduceSanity)
        {
            sanitySlider.value -= Time.deltaTime;
            //velocidad del jugador se va disminuyendo
            
            if (sanitySlider.value == 0)
                GameManager.instance.GameOver();

            // si la barra de sanidad es menor a x numero, la velocidad se reduce
            //relacionar el valor de la barra de sanidad con el numero de velocidad del jugador?
        }
        else
        {
            sanitySlider.value += Time.deltaTime;
            //La velocidad del jugador aumenta hasta llegar a su valor normal (HACER UN METODO CON PARAMETROS PARA NO REPETIR DOS VECES)

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
