using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]

public class Product : MonoBehaviour
{
    public string name;
    public string productDescription;
    public GameObject productObject;
    public int initialStock;
    public int currentStock;
    public int cost;

    //public string productType; //puede ser un objeto a un evento como un dialogo ("object" - "event"), usar esto hace que sea menos expandible y mas sucio el codigo


    //hacer clases hijas con un mismo metodo para que cada producto tenga una forma de actuar distinta.
    //por ejemplo los objetos se almacenan en un inventario o lista al ser comprados y los eventos muestran dialogos o cinematicas en el momento
    //esta opcion es mas limpia y expandible
}

