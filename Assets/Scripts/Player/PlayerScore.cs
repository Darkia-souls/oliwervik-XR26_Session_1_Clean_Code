using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int score = 0;
    private UIManager uiManager;

    private void Start()
    {
        uiManager = Object.FindFirstObjectByType <UIManager>();
        uiManager.UpdateScore(score);
    }

    
    public void AddScore(int amount)
    {
        score += amount;
        uiManager.UpdateScore(score);
        
        //Notify GameManager about new score
        GameManager.Instance.ReportScore(score);
    }
    
    public int GetScore() => score;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            AddScore(10);
            Destroy(collision.gameObject);
        }
    }
}
