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
        //ac� se puede activar la linea de dialogo despu�s
        ProductButton.interactable = false;
    }
}
