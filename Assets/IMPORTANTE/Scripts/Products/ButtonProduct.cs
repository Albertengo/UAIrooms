using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonProduct : MonoBehaviour
{
    public void OutOfStock()
    {
        //ac� se puede activar la linea de dialogo despu�s
        gameObject.GetComponent<Button>().interactable = false;
    }
}
