using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Store : MonoBehaviour
{
    [Header("OTHER SCRIPTS")]
    PlayerMovement playerMovement;
    UAIcoins uaiCoins;

    [Header("UI")]
    [SerializeField] GameObject storeUI;

    [Header("PRODUCT INFORMATION LIST")]
    [SerializeField] List<GameObject> products;
    [SerializeField] List<int> stocks;
    [SerializeField] List<int> costs;
    //[SerializeField] List<TextMeshProUGUI> stockText;


    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        uaiCoins = player.GetComponent<UAIcoins>();

        storeUI.SetActive(false);
    }



    public void Buy(int productNumber)
    {
        //acceder al costo del prefab
        if (stocks[productNumber] > 0 &&  uaiCoins.Coins >= costs[productNumber])
        {
            uaiCoins.Coins -= costs[productNumber];
            stocks[productNumber] -= 1;

            uaiCoins.ShowCoins();
            //stockText[productNumber];
            //actualizar texto de moneda y stock del articulo
            //añadir a inventario de jugador

            //agregar descripcion de objeto (
        }
        else { Debug.Log("El dinero no es suficiente par comprar este articulo"); /*tirar dialogo o aviso de que no es posible realizar la compra*/ }

        //- revisa si la cantidad de moneda es suficiente con un if y si hay stock de el producto
        // si la cantidad de monedas es suficiente se descuenta el dinero y se resta el stock - si no es suficiente tirar un aviso o dialogo del vendedor
        //actalizarf texto de monedas disponibles y stocks
        // se entrega el producto al jugador (añadir a una lista para que el jugador pueda usarlo mas tarde)
    }


    void QuitStore()
    {
        // si se presiona la opcion de salir el jugador puede moverse libremente nuevamente (bool)
        playerMovement.canMove = true; //metodo de movimeinto

        storeUI.SetActive(false);
        //desactivar canva de tienda

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //el mouse se esconde y bloquea nuevamente

    }

    void EnterStore()
    {
        // se activa el canva de la tienda
        storeUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //el mouse es visible nuevamente y no esta bloqueado


        playerMovement.canMove = false; //todo lo realcionado con el movimiento del jugador se podria englobar en un metodo
        //camara no puede moverse
        // Rotar y moverse automaticamente hacia la tienda suavemente
    }
}
