using System;
using TMPro;
using UnityEngine;

public class UIStats : MonoBehaviour
{
    [SerializeField] private TMP_Text txtHealth;
    [SerializeField] private TMP_Text txtSpeed;
    [SerializeField] private TMP_Text txtMoney;
    
    private PlayerStats _stats;

    private void Start()
    {
        _stats = Player.Instance.stats;
        PlayerStats.OnStatsUpdated += UpdateStats;
        PlayerWallet.OnWalletChange += UpdateMoney;
        UpdateStats();
        UpdateMoney();
    }

    private void OnDestroy()
    {
        PlayerStats.OnStatsUpdated -= UpdateStats;
        PlayerWallet.OnWalletChange -= UpdateMoney;
    }

    private void UpdateStats()
    {
        txtHealth.text = $"Health: {_stats.currentStats.health}";
        txtSpeed.text = $"Speed: {_stats.currentStats.speed}";
    }

    private void UpdateMoney()
    {
        txtMoney.text = $"Money: {Player.Instance.wallet.GetCurrentBalance()}";
    }
}
