using UnityEngine;
using UnityEngine.UI;

public class SimpleHealthBar : MonoBehaviour
{
    public RectTransform healthBarFill;
    public int maxHealth = 10;
    private int currentHealth;
    
    private Vector2 originalSize;
    private Image healthBarImage;
    
    void Start()
    {
        currentHealth = maxHealth;
        
        if (healthBarFill != null)
        {
            originalSize = healthBarFill.sizeDelta;
            healthBarImage = healthBarFill.GetComponent<Image>();
            Debug.Log("Health bar initialized. Original size: " + originalSize + ", Max health: " + maxHealth);
        }
        
        UpdateHealthBar();
    }
    
    public void OnDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        
        Debug.Log("Took " + damage + " damage! Health: " + currentHealth + "/" + maxHealth);
        UpdateHealthBar();
        
        if (currentHealth <= 0)
        {
            Debug.Log("Player died!");
            
            // Find and call GameOverManager
            GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
            if (gameOverManager != null)
            {
                gameOverManager.ShowGameOver();
            }
        }
    }
    
    public void OnHeal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        
        Debug.Log("Healed " + healAmount + "! Health: " + currentHealth + "/" + maxHealth);
        UpdateHealthBar();
    }
    
    void UpdateHealthBar()
    {
        if (healthBarFill != null && originalSize.x > 0)
        {
            float healthPercent = (float)currentHealth / maxHealth;
            Vector2 newSize = new Vector2(originalSize.x * healthPercent, originalSize.y);
            healthBarFill.sizeDelta = newSize;
            
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