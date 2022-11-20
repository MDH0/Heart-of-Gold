using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    private Vector2 movementVector;
    private Rigidbody2D rb;
    public float moveSpeed;
    private Animator animator;
    
    public bool useRb;

    public void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        movementVector = new Vector2(0f, 0f);

    }
    

    private void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movementVector * moveSpeed * Time.fixedDeltaTime);




    }

    
    public void SetMovement(Vector2 vector, string state)
    {
        movementVector = vector;
        

        if (state.Equals("Performed"))
        {
            animator.SetFloat("X", vector.x);
            animator.SetFloat("Y", vector.y);
        }

    }

    
}
