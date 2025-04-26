using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class Metronome : MonoBehaviour
{

    AudioSource audioSource;

    public float bpm = 120f;          
    public float multiplier = 1f;     

    private float nextTickTime;
    private float interval;

    public UnityEvent OnTick;
    public bool isStarted;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateInterval();
        nextTickTime = Time.time + interval;
    }

    void Update()
    {
        if (!isStarted) return;

        if (Time.time >= nextTickTime)
        {
            Tick();
            UpdateInterval();
            nextTickTime += interval;
        }
    }

    void UpdateInterval()
    {
        float adjustedBpm = bpm;

        if (multiplier >= 1f)
        {
            adjustedBpm *= multiplier;
        }
        else if (multiplier > 0f)
        {
            adjustedBpm *= multiplier;
        }
        else
        {
            multiplier = 0.01f; 
            adjustedBpm *= multiplier;
        }

        interval = 60f / adjustedBpm;
    }

    void Tick()
    {
        audioSource.Play();
        OnTick.Invoke();
    }

    public void SetBpmAndMultiplier(float newBpm, float newMultiplier)
    {
        bpm = Mathf.Max(newBpm, 1f);
        multiplier = Mathf.Max(newMultiplier, 0.01f);
        UpdateInterval();
    }
}