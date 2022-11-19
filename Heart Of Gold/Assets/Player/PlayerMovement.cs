using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movementVector;
    private Rigidbody2D rb;
    public float moveSpeed;
    private Animator animator;
    private string movementState;
    public void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        movementState = "";
        movementVector = new Vector2(0, 0);
    }
    public void move(InputAction.CallbackContext context)
    {
        
        movementState = context.phase.ToString();
        movementVector = context.ReadValue<Vector2>();
        /*float x = movementVector.x;
        
        float y = movementVector.y;
        Debug.Log("X: " + x + " Y: " + y);
        */
        


    }

    private void Update()
    {
        rb.MovePosition(rb.position + movementVector.normalized * Time.deltaTime * moveSpeed);
        
        
        
        if (movementState.Equals("Performed"))
        {
            animator.SetFloat("X", movementVector.x);
            animator.SetFloat("Y", movementVector.y);
        }
                
    }
}
