using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonProduct : MonoBehaviour
{
    [SerializeField] Button ProductButton;
    void Start()
    {
        //ProductButton.interactable = true; //por las dudas pero ni idea si es realmente necesario tbh.....
    }

    public void OutOfStock()
    {
        //acá se puede activar la linea de dialogo después
        ProductButton.interactable = false;
    }
}
