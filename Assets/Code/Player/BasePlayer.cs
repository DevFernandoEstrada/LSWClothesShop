using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(PlayerInteractions))]
[RequireComponent(typeof(PlayerAnimations))]
[RequireComponent(typeof(PlayerWallet))]
public abstract class BasePlayer : MonoBehaviour
{
    [HideInInspector] public PlayerMovement movement;
    [HideInInspector] public PlayerStats stats;
    [HideInInspector] public PlayerInventory inventory;
    [HideInInspector] public PlayerInteractions interactions;
    [HideInInspector] public PlayerAnimations animations;
    [HideInInspector] public PlayerWallet wallet;

    public void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        stats = GetComponent<PlayerStats>();
        inventory = GetComponent<PlayerInventory>();
        interactions = GetComponent<PlayerInteractions>();
        animations = GetComponent<PlayerAnimations>();
        wallet = GetComponent<PlayerWallet>();
    }
}