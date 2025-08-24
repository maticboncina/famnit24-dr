using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class MockAddToCart : MonoBehaviour
{
    public UnityEvent<int> addToCart;

    async void Start()
    {
        await Task.Delay(3000);
        SimulateAddToCart(1);
        await Task.Delay(3000);
        SimulateAddToCart(2);
    }

    private void SimulateAddToCart(int productId)
    {
        addToCart.Invoke(productId);
        Debug.Log("Added to Cart");
    }
}
