using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private Slider _volumeSlider;
    private float _numberForCorrection = 20;

    private void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float sliderValue)
    {
        _mixer.audioMixer.SetFloat(_volumeSlider.name, Mathf.Log10(sliderValue) * _numberForCorrection);

        if (sliderValue == 0)
            _mixer.audioMixer.SetFloat(_volumeSlider.name, -80);
    }
}