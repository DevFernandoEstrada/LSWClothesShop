using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _money;
    public static event Action OnWalletChange;

    private int Money
    {
        get => _money;
        set
        {
            _money = value;
            OnWalletChange?.Invoke();
        }
    }

    private void Start()
    {
        Money = 300;
    }

    public void DepositMoney(int quantity)
    {
        Money += quantity;
    }

    public bool WithdrawMoney(int quantity)
    {
        if (quantity > Money)
        {
            return false;
        }

        Money -= quantity;
        return true;
    }

    public int GetCurrentBalance()
    {
        return Money;
    }
}