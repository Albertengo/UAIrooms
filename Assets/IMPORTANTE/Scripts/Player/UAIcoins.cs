using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UAIcoins : MonoBehaviour
{
    public int Coins;
    [SerializeField] TextMeshProUGUI CoinText;
    [SerializeField] bool Hay_Texto_En_Escena;
    void Start()
    {
        if (Hay_Texto_En_Escena)
        {
            CoinText = GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShowCoins();
    }

    void ShowCoins()
    {
        if (Hay_Texto_En_Escena)
        {
            CoinText.text = "UAIcoins: " + Coins;
        }
    }

    public void Tienda(int costo) //habria q agregar codigo para que no salgan numeros negativos 
    {
        Coins = Coins - costo;
    }
}
