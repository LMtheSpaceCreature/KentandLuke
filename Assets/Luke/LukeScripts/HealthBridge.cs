using UnityEngine;

public class HealthBridge : MonoBehaviour
{
    private SimpleHealthBar healthBar;
    
    void Start()
    {
        healthBar = GetComponent<SimpleHealthBar>();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHealthChange(collision.gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        HandleHealthChange(other.gameObject);
    }
    
    void HandleHealthChange(GameObject obj)
    {
        var modifyHealth = obj.GetComponent("ModifyHealthAttribute");
        if (modifyHealth != null && healthBar != null)
        {
            var healthChangeField = modifyHealth.GetType().GetField("healthChange");
            if (healthChangeField != null)
            {
                int healthChange = (int)healthChangeField.GetValue(modifyHealth);
                
                if (healthChange < 0)
                {
                    healthBar.OnDamage(-healthChange);
                    Debug.Log("Took " + (-healthChange) + " damage");
                }
                else if (healthChange > 0)
                {
                    healthBar.OnHeal(healthChange);
                    Debug.Log("Healed " + healthChange);
                }
            }
        }
    }
}