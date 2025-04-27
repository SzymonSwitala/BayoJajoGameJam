using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

  
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private GameObject interfaceScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI gameOverTimerText;
    [SerializeField] private BeatTempoManager beatTempoManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        interfaceScreen.SetActive(true);
        beatTempoManager.StartBeat();
        gameTimer.isStarted = true;
   
    }


    public void GameOver()
    {
        interfaceScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        beatTempoManager.StopBeat();
        gameTimer.isStarted = false;

        gameOverTimerText.text = "Score : " + gameTimer.GetTime();
    }
}
