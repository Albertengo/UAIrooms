using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Store : MonoBehaviour
{
    [Header("OTHER SCRIPTS")]
    public CinemachineInputProvider inputProvider;
    public PlayerMovement playerMovement;
    public UAIcoins uaiCoins;
    public ButtonProduct buttonProduct;


    [Header("UI PANELS")]
    [SerializeField] GameObject storeUI;
    [SerializeField] GameObject descriptionPanel;

    [Header("TEXT")]
    [SerializeField] TextMeshProUGUI costText;
    //[SerializeField] TextMeshProUGUI stockText;
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

        GameObject button = GameObject.FindGameObjectWithTag("ProductButton");
        buttonProduct = button.GetComponent<ButtonProduct>();

        ResetStocks();
        storeUI.SetActive(false);
        descriptionPanel.SetActive(false);
 
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
        else if (newProduct.currentStock == 0)
            buttonProduct.OutOfStock();
        //Debug.Log("No hay suficiente initialStock");
        else
        { Debug.Log("El dinero no es suficiente para comprar este articulo"); /*tirar dialogo, sonido o aviso de que no es posible realizar la compra*/ }
    }

    //El numero de producto ("productNum") debe de coincidir con el boton del item
    public void UpdateDescriptionInformation(int productNum) 
    {
        Product newProduct = products[productNum];

        costText.text = newProduct.cost.ToString();
        nameText.text = newProduct.name.ToString();
        descriptionText.text = newProduct.productDescription.ToString();

        productNumber = productNum;
        descriptionPanel.SetActive(true);
    }

    private void ResetStocks()
    {
        for (int i = 0; i < products.Count; i++)
        {
            products[i].currentStock = products[i].initialStock;
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

        inputProvider.enabled = !activeStoreUI;
        playerMovement.canMove = !activeStoreUI; //mover lentamente el jugador hacia la tienda, rotar camara y bloquearla
    }
}
