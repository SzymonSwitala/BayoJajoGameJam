using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] music;
    public bool isPlaying;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (isPlaying && !audioSource.isPlaying)
        {
            int randomIndex = Random.Range(0,music.Length);
            audioSource.clip = music[randomIndex];
            audioSource.Play();
        }
    }
    public void PlayMusic()
    {
        isPlaying = true;
       
    }

    public void StopMusic()
    {
        isPlaying = false;
        audioSource.Stop();
    }

   public void ChangeSpeed(float speedMultipler)
    {
        audioSource.pitch = speedMultipler;
    }
}
