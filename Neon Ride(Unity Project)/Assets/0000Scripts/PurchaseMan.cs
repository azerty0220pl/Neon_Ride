/*
 * Purchase Manager
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last modification: 18/04/21
 * 
 * Buy premium
 */
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using UnityEngine.Advertisements;

public class PurchaseMan : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    public static string premium = "neonridenoads";

    public GameObject errorObj;
    public Text errorText;

    void Start()
    {
        if (m_StoreController == null && m_StoreExtensionProvider == null)
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            builder.AddProduct(premium, ProductType.NonConsumable);

            UnityPurchasing.Initialize(this, builder);
        }

        if (PlayerPrefs.GetInt("premium") == 2002)
            this.gameObject.SetActive(false);
    }

    public void buyPremium()
    {
        if (m_StoreController != null && m_StoreExtensionProvider != null)
        {
            Product product = m_StoreController.products.WithID(premium); 

            if (product != null && product.availableToPurchase)
            {
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                errorObj.SetActive(true);
                errorText.text = "Product not found.\nSorry for the trouble.";
            }
        }
        else
        {
            errorObj.SetActive(true);
            errorText.text = "Could not buy product. Please make sure you have internet connection and if you do have, please wait for the game to connect to Google Play." +
                "\n Sorry for the trouble.";
            Start();
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // Purchasing has succeeded initializing. Collect our Purchasing references.
        Debug.Log("OnInitialized: PASS");

        // Overall Purchasing system, configured with products for this application.
        m_StoreController = controller;
        // Store specific subsystem, for accessing device-specific store features.
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }


    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        // Or ... a non-consumable product has been purchased by this user.
        if (string.Equals(args.purchasedProduct.definition.id, premium, StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            PlayerPrefs.SetInt("premium", 2002);
            Advertisement.Banner.Hide();
            this.gameObject.SetActive(false);
            errorObj.SetActive(true);
            errorText.text = "Thank you for supporting me :)";
            // TODO: The non-consumable item has been successfully purchased, grant this item to the player.
        }
        return PurchaseProcessingResult.Complete;
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
        // this reason with the user to guide their troubleshooting actions.
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }

}
