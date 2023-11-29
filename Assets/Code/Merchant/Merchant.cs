using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MerchantView))]
public class Merchant : MonoBehaviour, IInteractable
{
    [SerializeField, Range(0.1f, 0.5f)] private float overPricePercent = 0.1f;
    [SerializeField] private List<GearSet> gearSets = new();

    private MerchantView _view;

    private void Start()
    {
        _view = GetComponent<MerchantView>();
    }

    private void ConfirmSellGearSet(GearSet gearSet)
    {
        int merchantValue = Mathf.FloorToInt(gearSet.value * (1 + overPricePercent));
        if (Player.Instance.wallet.GetCurrentBalance() > merchantValue)
        {
            UIManager.Instance.ShowItemDescription(gearSet, merchantValue.ToString(), "Buy", SellGearSet);
            return;
        }
        UIManager.Instance.ShowItemDescription(gearSet, merchantValue.ToString(), "Close");
    }
    
    private void SellGearSet(GearSet gearSet)
    {
        int merchantValue = Mathf.FloorToInt(gearSet.value * (1 + overPricePercent));
        Player.Instance.wallet.WithdrawMoney(merchantValue);
        Player.Instance.inventory.AddGearSet(gearSet);
        gearSets.Remove(gearSet);
        UIManager.Instance.RefreshItems();
    }

    private void ConfirmBuyGearSet(GearSet gearSet)
    {
        UIManager.Instance.ShowItemDescription(gearSet, gearSet.value.ToString(), "Sell", BuyGearSet);
    }
    
    private void BuyGearSet(GearSet gearSet)
    {
        Player.Instance.wallet.DepositMoney(gearSet.value);
        Player.Instance.inventory.RemoveGearSet(gearSet);
        gearSets.Add(gearSet);
        UIManager.Instance.RefreshItems();
    }

    public void OpenStore()
    {
        UIItemsData uiItemsData;
        uiItemsData.header = "Shop";
        uiItemsData.leftPanel = "Buy";
        uiItemsData.rightPanel = "Sell";
        uiItemsData.leftGearSet = gearSets;
        uiItemsData.rightGearSet = Player.Instance.inventory.gearSets;
        uiItemsData.leftCallback = ConfirmSellGearSet;
        uiItemsData.rightCallback = ConfirmBuyGearSet;
        
        UIManager.Instance.ShowItems(uiItemsData);
        Player.Instance.movement.EnableMovement(false);
    }

    public void EnableInteract()
    {
        _view.EnableUIButton(true);
    }

    public void DisableInteract()
    {
        _view.EnableUIButton(false);
    }
}