using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float time = 0f;
    [SerializeField] private TextMeshProUGUI timerText;
    public bool isStarted = false;

    private void Update()
    {
        if (!isStarted) return;
        UpdateTimer();
    }
    void UpdateTimer()
    {
        time += Time.deltaTime;
        timerText.text = GetTime();
    }

    public string GetTime()
    {
        string text;
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        text = string.Format("{0:00}:{1:00}", minutes, seconds);
        return text;
    }
}
