using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private int health = 3;
    [SerializeField] private TextMeshProUGUI showingPlayerHealth;

    [SerializeField] private SoundPlayer soundPlayer;

    [SerializeField] private GameLost gameLost;

    public bool isPlayerAlive = true;

    private void Start()
    {
        showingPlayerHealth.text = $"Health: {health}";
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        showingPlayerHealth.text = $"Health: {health}";
        if (health <= 0)
        {
            isPlayerAlive = false;
            Destroy(gameObject);
            soundPlayer.SetValueAfterLoss(-80);
            gameLost.ShowCanvas();
        }
    }
}
