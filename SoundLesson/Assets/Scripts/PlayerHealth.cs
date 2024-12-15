using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private int health = 3;
    [SerializeField] private TextMeshProUGUI showingPlayerHealth;

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
            SceneManager.LoadScene(1);
        }
    }
}
