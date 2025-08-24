using UnityEngine;

public class CartManager : MonoBehaviour
{
    // This method will be hooked up in the Inspector
    public void OnAddToCart(int productId)
    {
        Debug.Log("🛒 UnityEvent fired! Product ID: " + productId);
        // Here you can add productId to a list, call an API, etc.
    }
}
