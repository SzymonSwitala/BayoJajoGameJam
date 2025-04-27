using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class BeatTempoManager : MonoBehaviour
{
    [SerializeField] private Metronome metronome;
    [SerializeField] private MusicManager musicManager;

    [SerializeField] private float speedIncrease = 0.1f;
    [SerializeField] private float multipler = 1;
    [SerializeField] private float increaseSpeedAfterSec;
    public UnityEvent OnIncreseSpeed;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= increaseSpeedAfterSec)
        {
            timer = 0f;
            IncreaseSpeed();
        }
    }
    public void StartBeat()
    {
        metronome.isStarted = true;
        musicManager.PlayMusic();
    }

    public void StopBeat()
    {
        metronome.isStarted = false;
        musicManager.StopMusic();
    }

    void IncreaseSpeed()
    {
        multipler += speedIncrease;
        OnIncreseSpeed.Invoke();
        musicManager.ChangeSpeed(multipler);
        metronome.SetMultiplier(multipler);
    }
}
