using UnityEngine;
using System.Collections;

public class RandomRespawn : MonoBehaviour
{
    public float respawnTime = 10f;
    
    private Vector3 startPosition;
    private SpriteRenderer spriteRenderer;
    private Collider2D col;
    
    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        Debug.Log("RandomRespawn initialized at: " + startPosition);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Only trigger for Player, not enemies
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player picked up health bonus!");
            StartCoroutine(RespawnRoutine());
        }
        else
        {
            Debug.Log("Non-player touched health bonus, ignoring: " + other.gameObject.name);
        }
    }
    
    IEnumerator RespawnRoutine()
    {
        // Hide visually and disable collider
        spriteRenderer.enabled = false;
        col.enabled = false;
        Debug.Log("HealthBonus hidden, waiting " + respawnTime + " seconds...");
        
        yield return new WaitForSeconds(respawnTime);
        
        // Move back and show again
        transform.position = startPosition;
        spriteRenderer.enabled = true;
        col.enabled = true;
        
        Debug.Log("HealthBonus respawned at: " + startPosition);
    }
}