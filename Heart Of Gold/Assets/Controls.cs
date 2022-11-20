using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerInteract playerInteract;
    private string movementState;
    private Vector2 movementVector;
    private void Awake()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerInteract = gameObject.GetComponent<PlayerInteract>();
        movementState = "";
        movementVector = new Vector2(0f, 0f);
    }
    public void Move(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>();
        movementState = context.phase.ToString();


    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
            playerInteract.Interact();

    }

    private void Update()
    {
        playerMovement.SetMovement(movementVector, movementState);
    }
}
