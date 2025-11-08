using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minY = -4f;  // Bottom boundary
    [SerializeField] private float maxY = 4f;   // Top boundary
    
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Set gravity to 0 (no gravity in space!)
        rb.gravityScale = 0f;
        
        // Prevent rotation
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    
    void Update()
    {
        // Get input from W/S or Up/Down arrow keys
        float moveInput = Input.GetAxisRaw("Vertical");
        
        // Move the player
        rb.linearVelocity = new Vector2(0, moveInput * moveSpeed);
        
        // Clamp position to stay within bounds
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector2(transform.position.x, clampedY);
    }
}