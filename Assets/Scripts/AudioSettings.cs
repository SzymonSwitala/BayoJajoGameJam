using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings: MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = 0.5f;
       
       
        SetVolume(volumeSlider.value);
  
       
    }

    public void SetVolume(float sliderValue)
    {
       
       float volume = Mathf.Log10(sliderValue) * 20;
       audioMixer.SetFloat("Volume", volume);
    }
}