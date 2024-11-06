using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MuteButton : MonoBehaviour
{
    [SerializeField] private AudioListener _listener;
    [SerializeField] private Button _muteButton;

    private bool _isEnabled = true;

    private void OnEnable()
    {
        _muteButton?.onClick.AddListener(Mute);
    }

    private void OnDisable()
    {
        _muteButton?.onClick.RemoveListener(Mute);
    }

    private void Mute()
    {
        if (_isEnabled == false)
        {
            _listener.enabled = true;
        }
        else
        {
            _listener.enabled = false;
        }

        _isEnabled = !_isEnabled;
    }
}