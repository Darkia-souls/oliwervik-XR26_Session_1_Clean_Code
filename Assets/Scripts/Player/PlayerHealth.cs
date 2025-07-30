using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 30f;
    private float currentHealth;
    private UIManager uiManager;
    private GameManager gameManager;
    
    void Start()
    {
        currentHealth = maxHealth;
        uiManager = Object.FindFirstObjectByType<UIManager>();
        gameManager = FindObjectOfType<GameManager>();
        
        uiManager.UpdateHealth(currentHealth, maxHealth);
    }
    
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        uiManager.UpdateHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            GameManager.Instance.PlayerDied();
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
            Destroy(collision.gameObject);
        }
    }
}
