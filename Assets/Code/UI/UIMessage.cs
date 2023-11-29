using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMessage : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTitle;
    [SerializeField] private TMP_Text txtMessage;
    [SerializeField] private TMP_Text txtButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button actionButton;
    
    private void Start()
    {
        closeButton.onClick.AddListener(CloseItemDescription);
    }

    public void Setup(string header, string message, string actionButtonText, Action callback = null)
    {
        txtTitle.text = header;
        txtMessage.text = message;
        txtButton.text = actionButtonText;
        if (callback != null)
        {
            actionButton.onClick.AddListener(() =>
            {
                callback();
                CloseItemDescription();
            });
        }
        else
        {
            actionButton.onClick.AddListener(CloseItemDescription);
        }
    }

    private void CloseItemDescription()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        actionButton.onClick.RemoveAllListeners();
        closeButton.onClick.RemoveAllListeners();
    }
}
