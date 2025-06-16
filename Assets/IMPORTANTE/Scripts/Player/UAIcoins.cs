using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UAIcoins : MonoBehaviour
{
    public int coins;
    public int Coins
    {
        get { return coins; }
        set { coins = Mathf.Max(0, value); }
    }

    public TextMeshProUGUI CoinText;
    [SerializeField] bool Hay_Texto_En_Escena;


    void Start()
    {
        /*if (Hay_Texto_En_Escena)
        {
            CoinText = GetComponent<TextMeshProUGUI>();
        }*/

        
        Coins = 0;

        ShowCoins();
    }
    /*void Update()
    {
        ShowCoins();
    }*/


    public void ShowCoins()
    {
        //if (Hay_Texto_En_Escena)
        //{
            CoinText.text = "uaiCoins: " + Coins;
        //}
    }

    public void Tienda(int costo)
    {
        Coins = Coins - costo;
    }

    public void AddCoins(int CoinValue)
    {
        Coins = Coins + CoinValue;
        ShowCoins();
        //DestroyCoin();
    }

    //void DestroyCoin()
    //{
    //    Destroy(this.gameObject);
    //}
}
