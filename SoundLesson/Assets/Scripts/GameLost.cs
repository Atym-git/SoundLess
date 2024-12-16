using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLost : MonoBehaviour
{
    [SerializeField] private Button restartGameButton;

    [SerializeField] private Canvas gameLoseCanvas;

    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private SoundPlayer soundPlayer;

    private void Start()
    {
        restartGameButton.onClick.AddListener(RestartGame);
    }

    public void ShowCanvas()
    {
    gameLoseCanvas.gameObject.SetActive(true);
    }


    private void RestartGame()
    {
        playerHealth.isPlayerAlive = true;
        SceneManager.LoadScene(0);
        soundPlayer.SetValueAfterLoss(-20);
        soundPlayer.SetSlidersValue();
    }
}