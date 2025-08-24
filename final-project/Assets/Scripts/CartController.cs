using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    private List<ProductData> cart;
    public CartUI cartUI;
    private Dictionary<int, ProductData> productLookup;
    public TextAsset productsJson;
    
    public MockAddToCart addToCart;
    void OnEnable()
    {
        if (addToCart != null)
        {
            addToCart.addToCart.AddListener(OnAddToCart);
        }
    }
    private void Awake()
    {
        var shelfCollection = JsonUtility.FromJson<ProductDataCollection>(productsJson.text);
        productLookup = new Dictionary<int, ProductData>();
        foreach (var s in shelfCollection.products)
            productLookup[s.id] = s;

        cart = new List<ProductData>();    
    }

    public void OnAddToCart(int productId)
    {
        
        productLookup.TryGetValue(productId, out ProductData data);
        Debug.Log(data.name);

        if (data != null)
        {
            cart.Add(data);
            cartUI.AddToCart(data);
        }
        
    }
    void Update()
    {
        
    }
}
