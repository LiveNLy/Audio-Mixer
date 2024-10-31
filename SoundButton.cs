using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SoundButton : MonoBehaviour
{
    private Button _button;
    private AudioSource _sourse;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _sourse = GetComponentInChildren<AudioSource>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(PlaySound);
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlaySound);
    }

    private void PlaySound()
    {
        _sourse.Play();
    }
}