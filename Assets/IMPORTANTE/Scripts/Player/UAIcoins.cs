using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UAIcoins : MonoBehaviour
{
    private int coins;
    public int Coins
    {
        get { return coins; }
        set { coins = Mathf.Max(0, value); }
    }

    public TextMeshProUGUI CoinText;
    [SerializeField] bool Hay_Texto_En_Escena;


    void Start()
    {
        if (Hay_Texto_En_Escena)
        {
            CoinText = GetComponent<TextMeshProUGUI>();
        }
    }

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

    public void Tienda(int costo)
    {
        Coins = Coins - costo;
    }
}
