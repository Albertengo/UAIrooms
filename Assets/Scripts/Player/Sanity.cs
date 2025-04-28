using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    // Cuando el jugador entra en una zona trigger la barra va disminuyendo, pero cuando sale vuelve a recargarse
    //cuando la sanidad llega a 0 el jugador pierda
    //una baja sanida hace que la velocidad disminuya, en el caso de vik el radio de deteccion se vuelve mayor  

    [SerializeField] Slider sanitySlider;
    [SerializeField] float max;
    [SerializeField] float min;

    private bool reduceSanity = false;



    private void Start()
    {
        sanitySlider.value = max;
        sanitySlider.maxValue = max;
        sanitySlider.minValue = min;
    }

    private void Update()
    {
        if (reduceSanity && sanitySlider.value >= 0)
        {
            sanitySlider.value -= Time.deltaTime;

            // si la barra de sanidad es menor a x numero, la velocidad se reduce
            //relacionar la barra de sanidad con el numero de velocidad del jugador?
            //si la barra llega a 0 el jugador pierde
        }
        else
        {
            
        }
    }


    private void OnTriggerEnter(Collider other) //no se usa un OnTriggerStay para ahorrar recursos
    {
        if (other.gameObject.CompareTag("Sanity Zone"))
        {
            reduceSanity = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        reduceSanity = false;
    }
}
