using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Store : MonoBehaviour
{
    [Header("OTHER SCRIPTS")]
    public PlayerMovement playerMovement;
    public UAIcoins uaiCoins;

    [Header("UI PANELS")]
    [SerializeField] GameObject storeUI;
    [SerializeField] GameObject descriptionPanel;

    [Header("TEXT")]
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TextMeshProUGUI nameText;

    [Header("PRODUCT LIST")]
    [SerializeField] List<Product> products;
    [SerializeField] int productNumber;



    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        uaiCoins = player.GetComponent<UAIcoins>();

        storeUI.SetActive(false);
        descriptionPanel.SetActive(false);
        for (int i = 0; i < products.Count; i++) //poner en un metodo separado
        {
            products[i].currentStock = products[i].initialStock;
        }  
    }

    private void Update() // esto se debe de eliminar despues, es solo para probar si funciona la interfaz
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EnterStore();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            QuitStore();
        }
    }


    //Los metodos que estan como publicos se llaman desde botones de la UI
    public void Buy()
    {
        Product newProduct = products[productNumber];

        if (newProduct.currentStock > 0 && uaiCoins.Coins >= newProduct.cost)
        {
            uaiCoins.Coins -= newProduct.cost;
            newProduct.currentStock--;

            
            uaiCoins.ShowCoins();
            Debug.Log("Compra realizada");
            //añadir a "inventario" (inventory manager) de jugador, si es un dialogo (producto que no es del tipo objeto) entonces se triggerea el evento
        }
        else { Debug.Log("El dinero no es suficiente par comprar este articulo / No hay suficiente initialStock"); /*tirar dialogo, sonido o aviso de que no es posible realizar la compra*/ }
    }


    //mwtodo aparte que actualice la informacion y que se llame desde buy, agregar parametro del tipo poduct o int, se van reemplaxando los textos e imagen, este boton modifica el numero del producto que se usa asi coincide con el de buy
    public void UpdateDescriptionInformation(int productNum) //llamar desde los botones antes del buy
    {
        Product newProduct = products[productNum];

        costText.text = newProduct.cost.ToString();
        nameText.text = newProduct.name.ToString();
        descriptionText.text = newProduct.productDescription.ToString();

        productNumber = productNum;
        descriptionPanel.SetActive(true);
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
