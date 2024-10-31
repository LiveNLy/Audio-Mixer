using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MuteButton : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Button _muteButton;
    [SerializeField] private VolumeSlider _masterVolumeSlider; 

    private float _savedVolume = 0;
    private float _mutedVolume = -80;
    private bool _isEnabled = true;

    private void OnEnable()
    {
        _masterVolumeSlider.OnVolumeChanging += MakeEnabled;
        _muteButton?.onClick.AddListener(Mute);
    }

    private void OnDisable()
    {
        _masterVolumeSlider.OnVolumeChanging -= MakeEnabled;
        _muteButton?.onClick.RemoveListener(Mute);
    }

    private void Mute()
    {
        if (_isEnabled == false)
        {
            _mixer.audioMixer.SetFloat("MasterVolume", _savedVolume);
        }
        else
        {
            _mixer.audioMixer.GetFloat("MasterVolume", out _savedVolume);
            _mixer.audioMixer.SetFloat("MasterVolume", _mutedVolume);
        }

        _isEnabled = !_isEnabled;
    }

    private void MakeEnabled()
    {
        _isEnabled = true;
    }
}