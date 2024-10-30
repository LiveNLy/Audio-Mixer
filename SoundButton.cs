using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [SerializeField] AudioSource _sourse;

    public void PlaySound()
    {
        _sourse.Play();
    }
}
