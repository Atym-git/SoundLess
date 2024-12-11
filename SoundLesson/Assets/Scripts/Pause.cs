using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button unPauseButton;
    [SerializeField] private Image pauseBackGround;

    public bool isGamePaused = false;

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        unPauseButton.onClick.AddListener(UnPauseGame);
    }

    private void PauseGame()
    {
        isGamePaused = true;
        pauseBackGround.gameObject.SetActive(true);
        pauseBackGround.gameObject.transform.position = transform.position + new Vector3 (0, 0, 10);
    }
    private void UnPauseGame()
    {
        isGamePaused = false;
        pauseBackGround.gameObject.SetActive(false);
    }
}
