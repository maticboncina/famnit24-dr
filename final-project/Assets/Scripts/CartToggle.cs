using UnityEngine;

public class CartToggle : MonoBehaviour
{
    [Header("References")]
    public GameObject cartPanel;   // assign your CartPanel here

    public void ToggleCart()
    {
        if (cartPanel != null)
        {
            bool isActive = cartPanel.activeSelf;
            cartPanel.SetActive(!isActive);
        }
    }
}
