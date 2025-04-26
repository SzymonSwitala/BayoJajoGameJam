using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField] private Metronome metronome;
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private GameObject interfaceScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI gameOverTimerText;
    

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
        metronome.isStarted = true;
        gameTimer.isStarted = true;
   
    }


    public void GameOver()
    {
        interfaceScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        metronome.isStarted = false;
        gameTimer.isStarted = false;

        gameOverTimerText.text = "Przeżyłeś " + gameTimer.GetTime();
    }
}
