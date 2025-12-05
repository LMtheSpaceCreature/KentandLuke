using UnityEngine;

public class PickupSound : MonoBehaviour
{
    public AudioClip pickupSound;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position, 1f);
        }
    }
}