using UnityEngine;

public class Merchant : MonoBehaviour, IInteractable
{
    public void EnableInteract()
    {
        print($"Do you want some clothes?");
    }

    public void DisableInteract()
    {
        print($"You'll regret not buying!");
    }
}
