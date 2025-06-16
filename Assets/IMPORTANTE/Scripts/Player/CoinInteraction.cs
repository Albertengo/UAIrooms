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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddCoins();
        }
    }


    public void AddCoins()
    {
        PlayerCoins.AddCoins(1);
        Debug.Log("moneda recolectada");
        DestroyCoin(); 
    }

    void DestroyCoin()
    {
        Destroy(this.gameObject); 
}
}
