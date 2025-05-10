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
    [SerializeField] List<Product> products;

    [SerializeField] List<GameObject> allProductsDescriptions;
    //[SerializeField] List<GameObject> products;
    [SerializeField] List<int> stocks;
    [SerializeField] List<int> costs;
    [SerializeField] List<TextMeshProUGUI> stockText; //ver si hay alguna forma de no usar tantas listas


    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        uaiCoins = player.GetComponent<UAIcoins>();

        storeUI.SetActive(false);
    }



    public void Buy(int productNumber)
    {
        Product newProduct = products[productNumber];

        if (newProduct.stock > 0 &&  uaiCoins.Coins >= newProduct.cost)
        {
            uaiCoins.Coins -= newProduct.cost;
            newProduct.stock--;

            uaiCoins.ShowCoins();
            newProduct.stockText.text = stocks[productNumber].ToString();
            //añadir a "inventario" de jugador
        }
        else { Debug.Log("El dinero no es suficiente par comprar este articulo"); /*tirar dialogo, sonido o aviso de que no es posible realizar la compra*/ }
    }

    public void ShowProductDescription(GameObject description)
    {
        for (int i = 0; products.Count > i; i++)
        {
            if (products[i].productDescription.activeInHierarchy)
            {
                products[i].productDescription.SetActive(false);
            } 
        }
        
       description.SetActive(true);
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
