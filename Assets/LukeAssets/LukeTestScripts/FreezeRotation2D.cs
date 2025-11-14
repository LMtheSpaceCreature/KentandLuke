using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FreezeRotation2D : MonoBehaviour
{
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Freeze rotation so the sprite doesn't flop around
            rb.freezeRotation = true;
        }
    }

    // Optional: enforce upright rotation every frame
    void LateUpdate()
    {
        if (rb != null)
        {
            rb.rotation = 0f; // Keep the player completely upright
        }
    }
}
