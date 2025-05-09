using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] GameObject storeUI;

    [SerializeField] List<GameObject> products;
    [SerializeField] List<int> stocks;
    [SerializeField] List<int> costs;


    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

        storeUI.SetActive(false);
    }



    public void Buy(int productNumber)
    {
        //acceder al costo del prefab
        //- revisa si la cantidad de moneda es suficiente con un if y si hay stock de el producto
        // si la cantidad de monedas es suficiente se descuenta el dinero y se resta el stock - si no es suficiente tirar un aviso o dialogo del vendedor
        //actalizarf texto de monedas disponibles y stocks
        // se entrega el producto al jugador (añadir a una lista para que el jugador pueda usarlo mas tarde)
    }

    public void Stock(int productStock)
    {
        productStock -= 1;
        //actualizar cantidad de stock
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
