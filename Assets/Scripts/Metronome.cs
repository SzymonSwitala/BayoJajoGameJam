using UnityEngine;
using UnityEngine.Events;

public class Metronome : MonoBehaviour
{
    [SerializeField] private float bpm = 60f;
    private AudioSource audioSource;
    public bool isStarted = false;

    private float nextClickTime;
    private float interval;

    public UnityEvent OnTick;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        interval = 60f / bpm;
        nextClickTime = Time.time;
    }
    void Update()
    {
        if (!isStarted) return;
        

            if (Time.time >= nextClickTime)
            {
                Tick();
                nextClickTime += interval;
            }
        
    }
    void Tick()
    {
        OnTick.Invoke();

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
