using UnityEngine;

public class Interactable_Message : MonoBehaviour, IInteractable
{

    [Header("Message")]
    [SerializeField] private string message;

    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        uiManager = ServiceHub.Instance.UIManager;

        if (uiManager == null) Debug.LogError("UIManager not found in ServiceHub.");
    }

    public void Interact()
    {
        uiManager.DisplayMessage(message);
    }

    public void Focused()
    {
       
    }

    public void UnFocused()
    {
        
    }
}
