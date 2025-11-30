using UnityEngine;

public class HealthBridge : MonoBehaviour
{
    private SimpleHealthBar healthBar;
    private int lastHealth;
    
    void Start()
    {
        healthBar = GetComponent<SimpleHealthBar>();
        lastHealth = 10; // Match your max health
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if we hit something with Modify Health
        var modifyHealth = collision.gameObject.GetComponent("ModifyHealthAttribute");
        if (modifyHealth != null && healthBar != null)
        {
            // Get the damage amount
            var healthChangeField = modifyHealth.GetType().GetField("healthChange");
            if (healthChangeField != null)
            {
                int damage = (int)healthChangeField.GetValue(modifyHealth);
                if (damage < 0) // negative = damage
                {
                    healthBar.OnDamage(-damage); // Convert to positive
                    Debug.Log("Took " + (-damage) + " damage from collision");
                }
            }
        }
    }
}