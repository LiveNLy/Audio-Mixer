using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    
    private Slider _volumeSlider;

    private void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
    }

    public void ChangeVolume(string parameterName)
    {
        _mixer.audioMixer.SetFloat(parameterName, Mathf.Log10(_volumeSlider.value) * 20);
    }
}