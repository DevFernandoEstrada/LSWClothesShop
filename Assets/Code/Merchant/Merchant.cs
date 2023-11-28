using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MerchantView))]
public class Merchant : MonoBehaviour, IInteractable
{
    [SerializeField, Range(10f, 50f)] private float overPricePercent = 10f;
    [SerializeField] private List<GearSet> gearSets = new();

    private MerchantView _view;

    private void Start()
    {
        _view = GetComponent<MerchantView>();
    }

    private void SellGearSet(GearSet gearSet)
    {
        Player.Instance.inventory.AddGearSet(gearSet);
        gearSets.Remove(gearSet);
        UIManager.Instance.RefreshItems();
    }

    private void BuyGearSet(GearSet gearSet)
    {
        Player.Instance.inventory.RemoveGearSet(gearSet);
        gearSets.Add(gearSet);
        UIManager.Instance.RefreshItems();
    }

    public void OpenStore()
    {
        UIItemsData uiItemsData;
        uiItemsData.header = "My store";
        uiItemsData.leftPanel = "Buy";
        uiItemsData.rightPanel = "Sell";
        uiItemsData.leftGearSet = gearSets;
        uiItemsData.rightGearSet = Player.Instance.inventory.gearSets;
        uiItemsData.leftCallback = SellGearSet;
        uiItemsData.rightCallback = BuyGearSet;
        
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