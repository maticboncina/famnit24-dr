using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CartUI : MonoBehaviour
{
    public static CartUI Instance;
    public RectTransform cartPanel;
    public GameObject cartItemPrefab;
    private List<string> cartItems = new List<string>();
    private Dictionary<string, GameObject> itemObjects = new Dictionary<string, GameObject>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (cartPanel == null)
        {
            Debug.LogError("Cart Panel not assigned in inspector.");
        }
        if (cartItemPrefab == null)
        {
            Debug.LogError("Cart Item Prefab not assigned in inspector.");
        }
    }

    public void AddToCart(ProductData data)
    {
        string productName = data.name;
        float productPrice = data.price;
        int productStock = data.stock;
        
        if (!cartItems.Contains(productName))
        {
            cartItems.Add(productName);
            GameObject itemObj = Instantiate(cartItemPrefab, cartPanel);
            itemObj.transform.Find("ProductName").GetComponent<TMPro.TMP_Text>().text = productName;
            itemObj.transform.Find("ProductPrice").GetComponent<TMPro.TMP_Text>().text = productPrice + "€";
            itemObj.transform.Find("ProductStock").GetComponent<TMPro.TMP_Text>().text = productStock + " item(s) in stock";
            Button removeBtn = itemObj.transform.Find("RemoveButton").GetComponent<Button>();
            removeBtn.onClick.AddListener(() => RemoveFromCart(productName));
            itemObjects[productName] = itemObj;
        }
    }

    public void RemoveFromCart(string productName)
    {
        if (cartItems.Contains(productName))
        {
            cartItems.Remove(productName);
            Destroy(itemObjects[productName]);
            itemObjects.Remove(productName);
        }
    }
}
