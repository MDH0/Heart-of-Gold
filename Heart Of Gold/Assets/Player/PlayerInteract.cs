using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private IInteractable focusedInteractable;
    private Rigidbody2D rb;
    public LayerMask layerMask;

    public float interactRadius;
    public Vector2 direction;
    

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = new Vector2(0, 1);
        
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.CircleCast(rb.position, interactRadius, direction, 0, layerMask.value, -Mathf.Infinity, Mathf.Infinity);



        if (hit.collider != null)
        {
            focusedInteractable = hit.collider.gameObject.GetComponent<IInteractable>();
            return;
        }
            
        focusedInteractable = null;
    }

    public void Interact()
    {
        if (focusedInteractable != null)
        {
            focusedInteractable.Interact();
        }
    }

    

}
