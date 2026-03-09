using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    public bool debugEnabled = false;


    private IInteractable targetInteractable;

    [SerializeField] private GameObject debugCurrentInteractable;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IInteractable foundInteractable))
        {
            targetInteractable = foundInteractable;
            debugCurrentInteractable = collision.gameObject;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable foundInteractable))
        {
            targetInteractable = null;
            debugCurrentInteractable = null;


        }
    }

    //When Interact input pressed call this
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (debugEnabled) Debug.Log("Attempting to interact");

            if (targetInteractable != null)
            {
                targetInteractable.Interact();
            }
            
        }
    }
}
