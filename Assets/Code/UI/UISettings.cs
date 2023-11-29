using UnityEngine;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    [SerializeField] private Button quitButton;

    private void Start()
    {
        quitButton.onClick.AddListener(CloseGame);
    }

    private void CloseGame()
    {
        UIManager.Instance.ShowMessage("Quit Game", "Are you sure to quit the game?", "Quit", Application.Quit);
    }
}