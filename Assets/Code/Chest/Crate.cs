using UnityEngine;

public class Crate : MonoBehaviour, IInteractable
{
    private CrateView _view;

    private void Start()
    {
        _view = GetComponent<CrateView>();
    }

    public void OpenCrate()
    {
        int moneyFound = Random.Range(10, 100);
        UIManager.Instance.ShowMessage("Lucky!", $"You just found {moneyFound} money!", "Jackpot!");
        Player.Instance.wallet.DepositMoney(moneyFound);
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