using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonProduct : MonoBehaviour
{
    public void OutOfStock()
    {
        //acá se puede activar la linea de dialogo después
        gameObject.GetComponent<Button>().interactable = false;
    }
}
