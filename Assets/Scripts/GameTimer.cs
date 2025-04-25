using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float time = 0f;
    [SerializeField] private TextMeshProUGUI timerText;

    private void Update()
    {
        UpdateTimer();
    }
    void UpdateTimer()
    {
        time += Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
