using UnityEngine;
using UnityEngine.UI;

public class SimpleHealthBar : MonoBehaviour
{
    public RectTransform healthBarFill;
    public Image healthBarImage; // Add this new field
    public int maxHealth = 10;
    private int currentHealth;
    
    private Vector2 originalSize;
    
    void Start()
    {
        currentHealth = maxHealth;
        
        if (healthBarFill != null)
        {
            originalSize = healthBarFill.sizeDelta;
            healthBarImage = healthBarFill.GetComponent<Image>();
            Debug.Log("Health bar initialized. Max health: " + maxHealth);
        }
        
        UpdateHealthBar();
    }
    
    // This gets called when player takes damage
    public void OnDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        
        Debug.Log("Took " + damage + " damage! Health: " + currentHealth + "/" + maxHealth);
        UpdateHealthBar();
        
        if (currentHealth <= 0)
        {
            Debug.Log("Player died!");
        }
    }
    
    void UpdateHealthBar()
    {
        if (healthBarFill != null && originalSize.x > 0)
        {
            // Update size
            float healthPercent = (float)currentHealth / maxHealth;
            Vector2 newSize = new Vector2(originalSize.x * healthPercent, originalSize.y);
            healthBarFill.sizeDelta = newSize;
            
            // Update color based on health
            if (healthBarImage != null)
            {
                if (currentHealth > 6)
                {
                    healthBarImage.color = Color.green;
                }
                else if (currentHealth >= 3)
                {
                    healthBarImage.color = Color.yellow;
                }
                else
                {
                    healthBarImage.color = Color.red;
                }
            }
        }
    }
}