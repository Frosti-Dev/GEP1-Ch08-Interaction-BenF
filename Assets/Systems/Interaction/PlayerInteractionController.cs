using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    public bool debugEnabled = false;


    private IInteractable targetInteractable;

    [SerializeField] private GameObject debugCurrentInteractable;

    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        uiManager = ServiceHub.Instance.UIManager;

        if (uiManager == null) Debug.LogError("UIManager not found in ServiceHub.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractable foundInteractable))
        {
            targetInteractable = foundInteractable;
            debugCurrentInteractable = collision.gameObject;

            uiManager.ShowPrompt();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable foundInteractable))
        {
            targetInteractable = null;
            debugCurrentInteractable = null;

            uiManager.HidePrompt();
        }
    }

    //When Interact input pressed call this
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (debugEnabled) Debug.Log("Attempting to interact");

            uiManager.HidePrompt();

            if (targetInteractable != null)
            {
                targetInteractable.Interact();
            }
            
        }
    }
}
