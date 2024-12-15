using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private Button restartGameButton;

    private void Start()
    {
        restartGameButton.onClick.AddListener(RestartAGame);
    }
    private void RestartAGame()
    {
        SceneManager.LoadScene(0);
    }
}