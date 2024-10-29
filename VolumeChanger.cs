using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _volumeSlider;

    private bool _enabled = true;

    public void ToggleMusic(string mixerName)
    {
        if (_enabled == false)
        {
            _enabled = true;
            _mixer.audioMixer.SetFloat("MasterVolume", 0);
        }
        else
        {
            _enabled = false;
            _mixer.audioMixer.SetFloat("MasterVolume", -80);
        }
    }

    public void ChangeVolume(string mixerName)
    {
        _mixer.audioMixer.SetFloat(mixerName, Mathf.Log10(_volumeSlider.value) * 20);
    }
}
