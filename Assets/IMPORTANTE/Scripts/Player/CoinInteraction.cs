using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteraction : MonoBehaviour
{
    //agregar int de valor random para la cantidad de monedas q se puede conseguir?
    [SerializeField] UAIcoins PlayerCoins;

    //esta funcion puede ser accedido desde detectionRange_2 para q se active esta funcion en caso de q el player interactue con monedas
    /*
    public void AddCoins()//(CoinValue)
    {
        PlayerCoins.coins = PlayerCoins.coins + 1;//(CoinValue);
        DestroyCoin();
        Debug.Log(PlayerCoins.coins);
    }
    */
    public void AddCoins()
    {
        PlayerCoins.AddCoins(1);
    }

    void DestroyCoin()
    {
        Destroy(this.gameObject);
    }
}
