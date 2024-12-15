using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button unPauseButton;
    [SerializeField] private Image pauseBackGround;

    [SerializeField] private SpriteRenderer[] EnemySr; //Those are Sr of other collidable gameobjects in the scene
    [SerializeField] private SpriteRenderer floorSr;
    private int massiveNum = 0;

    public bool isEnemyAlive;

    public bool isGamePaused = false;

    [SerializeField] private SoundPlayer soundPlayer;

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        unPauseButton.onClick.AddListener(UnPauseGame);
    }

    private void PauseGame()
    {
        isGamePaused = true;
        pauseBackGround.gameObject.SetActive(true);
        floorSr.enabled = false;
        foreach (var Sr in EnemySr)
        {
            if (EnemySr[massiveNum] != null)
            {
                EnemySr[massiveNum].enabled = false;
                massiveNum++;
            }
        }
        massiveNum = 0;
    }
    private void UnPauseGame()
    {
        isGamePaused = false;
        pauseBackGround.gameObject.SetActive(false);
        floorSr.enabled = true;
        foreach (var Sr in EnemySr)
        {
            if (EnemySr[massiveNum] != null)
            {
                EnemySr[massiveNum].enabled = true;
                massiveNum++;
            }
        }
        massiveNum = 0;
        //soundPlayer.GetSlidersValue();
    }
}