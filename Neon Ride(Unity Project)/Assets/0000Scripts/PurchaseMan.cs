/*
 * Purchase Manager
 * NEON RIDE
 * 
 * By: Szymon Kokot
 * Last modification: 09/04/21
 * 
 * Buy premium
 */
using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Advertisements;

public class PurchaseMan : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    public static string premium = "neonridenoads";

    void Start()
    {
        Debug.Log("Start()");
        if(PlayerPrefs.GetInt("premium") == 1)
            this.gameObject.SetActive(false);

        if (m_StoreController == null && m_StoreExtensionProvider == null)
        {
            Debug.Log("inside Start() if");
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            builder.AddProduct(premium, ProductType.NonConsumable);

            UnityPurchasing.Initialize(this, builder);
        }
    }

    public void buyPremium()
    {
        Debug.Log("Trying to start purchase...");
        if (m_StoreController != null && m_StoreExtensionProvider != null)
        {
            Debug.Log("Starting purchase..." + m_StoreController.products.WithID(premium));
            Product product = m_StoreController.products.WithID(premium); 

            if (product != null && product.availableToPurchase)
            {
                Debug.Log("Purchasing...");
                m_StoreController.InitiatePurchase(product);
                PlayerPrefs.SetInt("premium", 1);
                Advertisement.Banner.Hide();
                this.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("Not able to start the purchase :(");
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
