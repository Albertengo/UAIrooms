using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Store : MonoBehaviour
{
    [Header("OTHER SCRIPTS")]
    public UAIcoins uaiCoins;
    public MovementManager movementManager;

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

    [SerializeField] Transform newPlayerPosition;
    GameObject player;



    private void Start()
    {
        player = GameObject.Find("Player");
        uaiCoins = player.GetComponent<UAIcoins>();

        ResetStocks();
        storeUI.SetActive(false);
        descriptionPanel.SetActive(false);
 
    }



    public void Buy()
    {
        Product newProduct = products[productNumber];

        if (newProduct.currentStock > 0 && uaiCoins.Coins >= newProduct.cost)
        {
            uaiCoins.Coins -= newProduct.cost;
            newProduct.currentStock--;

            uaiCoins.ShowCoins();
            //añadir a "inventario" (inventory manager) de jugador, si es un dialogo (producto que no es del tipo objeto) entonces se triggerea el evento
        }
        else if (newProduct.currentStock == 0)
            FindButtonProduct(newProduct.name);
    }

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

    void FindButtonProduct(string productName)
    {
        GameObject button = GameObject.Find(productName);
        ButtonProduct buttonProduct = button.GetComponent<ButtonProduct>();
        buttonProduct.OutOfStock();
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

        movementManager.CameraRotation(!activeStoreUI);
        movementManager.ChangePlayerPostion(newPlayerPosition, !activeStoreUI);
    }
}
