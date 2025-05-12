using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonProduct : MonoBehaviour
{
    Button productButton;

    private void Start()
    {
        productButton = gameObject.GetComponent<Button>();
        productButton.enabled = true;
    }

    public void OutOfStock()
    {
        //ac� se puede activar la linea de dialogo despu�s
        productButton.interactable = false;
    }
}
