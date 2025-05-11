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

    [Header("PRODUCT LIST")]
    [SerializeField] List<Product> products;



    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        uaiCoins = player.GetComponent<UAIcoins>();

        storeUI.SetActive(false);
    }


    //Los metodos que estan como publicos se llaman desde botones de la UI
    public void Buy(int productNumber)
    {
        Product newProduct = products[productNumber];

        if (newProduct.stock > 0 &&  uaiCoins.Coins >= newProduct.cost)
        {
            uaiCoins.Coins -= newProduct.cost;
            newProduct.stock--;

            uaiCoins.ShowCoins();
            newProduct.stockText.text = newProduct.stock.ToString();
            //añadir a "inventario" (inventory manager) de jugador, si es un dialogo (producto que no es del tipo objeto) entonces se triggerea el evento
        }
        else { Debug.Log("El dinero no es suficiente par comprar este articulo"); /*tirar dialogo, sonido o aviso de que no es posible realizar la compra*/ }
    }


    public void ShowProductDescription(GameObject description) //en vez de que cada producto tenga un panel propio, que solo cambie la descripcion, nombre e imagen del producto(?, chequear numero de descripcion abierta para que buy tome el prodcuto correcto
    {
        description.SetActive(true);

        for (int i = 0; products.Count > i; i++)
        {
            if (products[i].productDescription.activeInHierarchy)
            {
                products[i].productDescription.SetActive(false);
            } 
        }
    }


    public void QuitStore()
    {
        StoreInteraction(false, CursorLockMode.Locked);
    }

    public void EnterStore() //llamar este metodo cuando se toca un trigger o se interactua
    {
        StoreInteraction(true, CursorLockMode.None);
    }

    void StoreInteraction(bool activeStoreUI, CursorLockMode cursorState) 
    {
        storeUI.SetActive(activeStoreUI);

        Cursor.visible = activeStoreUI;
        Cursor.lockState = cursorState;

        playerMovement.canMove = !activeStoreUI; //camara debe de bloquearse, rotar y moverse hacia la tienda
    }
}
