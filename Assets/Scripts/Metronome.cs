using UnityEngine;

public class Metronome: MonoBehaviour
{
    [SerializeField] private float bpm = 60f;
    private AudioSource audioSource;
   
    private float nextClickTime;
    private float interval;
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
        if (Time.time >= nextClickTime)
        {
            Click();
            nextClickTime += interval;
        }
    }
    void Click()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
