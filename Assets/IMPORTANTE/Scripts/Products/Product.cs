using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]

public class Product : MonoBehaviour
{
    public GameObject productObject;
    public string productDescription;
    public int initialStock;
    public int currentStock;
    public string name;
    public int cost;


    //hacer clases hijas con un mismo metodo para que cada producto tenga una forma de actuar distinta.
    //por ejemplo los objetos se almacenan en un inventario o lista al ser comprados y los eventos muestran dialogos o cinematicas en el momento
    //esta opcion es mas limpia y expandible
}

