using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ProductCard : MonoBehaviour
{
    // public event UnityEvent<int> ATC;
    public UnityEvent<int> ATC;

    [Header("Product Info")]
    public int productId;  // assign in Inspector

    [Header("UI References")]
    public Button addToCartButton;

    void Start()
    {
        if (addToCartButton != null)
        {
            addToCartButton.onClick.AddListener(OnAddToCartPressed);
        }
    }

    void OnAddToCartPressed()
    {
        Debug.Log("Add to Cart pressed for Product ID: " + productId);
        ATC?.Invoke(productId);     // fire UnityEvent with productId

        // Here you can send the product ID through an event, API, or UnityEvent
        // Example: EventManager.TriggerEvent("AddToCart", productId);
    }
}
