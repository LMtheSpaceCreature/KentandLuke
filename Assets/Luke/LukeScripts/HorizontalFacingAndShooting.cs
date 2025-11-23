using UnityEngine;

public class HorizontalFacingAndShooting : MonoBehaviour
{
    private Transform spriteVisual;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        // Find the child sprite object
        spriteVisual = transform.Find("SpriteVisual");
        if (spriteVisual != null)
        {
            spriteRenderer = spriteVisual.GetComponent<SpriteRenderer>();
        }
    }
    
    void Update()
    {
        if (spriteRenderer == null) return;
        
        // Only use WASD keys explicitly (not arrow keys)
        if (Input.GetKey(KeyCode.D)) // D key - face right/forward
        {
            spriteRenderer.flipX = false; // Face right horizontally
            transform.rotation = Quaternion.Euler(0, 0, 0); // Parent rotates for shooting
            spriteVisual.rotation = Quaternion.Euler(0, 0, 0); // Child stays upright
        }
        else if (Input.GetKey(KeyCode.A)) // A key - face left/backward
        {
            spriteRenderer.flipX = true; // Face left horizontally  
            transform.rotation = Quaternion.Euler(0, 0, 180); // Parent rotates for shooting
            spriteVisual.rotation = Quaternion.Euler(0, 0, 0); // Child counter-rotates to stay upright
        }
    }
}