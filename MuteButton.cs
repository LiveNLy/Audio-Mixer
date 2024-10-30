using UnityEngine;
using UnityEngine.Audio;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private bool _enabled = true;

    public void Mute(string parameterName)
    {
        if (_enabled == false)
        {
            _enabled = true;
            _mixer.audioMixer.SetFloat(parameterName, 0);
        }
        else
        {
            _enabled = false;
            _mixer.audioMixer.SetFloat(parameterName, -80);
        }
    }
}