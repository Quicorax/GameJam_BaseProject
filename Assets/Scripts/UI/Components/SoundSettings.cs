using Services.Runtime.AudioService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Scrollbar _musicScrollbar;
    [SerializeField] private Scrollbar _sfxScrollbar;

    [Inject] private IAudioService _audioService;

    private float _currentSFXVolume;
    private float _currentMusicVolume;

    private void Start()
    {
        _musicScrollbar.value = PlayerPrefs.GetFloat("MusicVolume");
        _sfxScrollbar.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void OnMusicVolumeChanged(float volume)
    {
        if (_currentMusicVolume == volume)
        {
            return;
        }

        _currentMusicVolume = volume;
        _audioService.SetMusicVolume(volume);
    }

    public void OnSFXVolumeChanged(float volume)
    {
        if (_currentSFXVolume == volume)
        {
            return;
        }

        _currentSFXVolume = volume;
        _audioService.SetSFXVolume(volume);
        //_audioService.PlaySFX("SFX");
    }
}