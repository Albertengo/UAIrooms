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
        //acá se puede activar la linea de dialogo después
        productButton.interactable = false;
    }
}
