using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer m_audioMixer;

    [SerializeField]
    private AudioMixerSnapshot m_gameMode, m_menuMode;

    public void SetMasterVoulme(float _volume)
    {
        m_audioMixer.SetFloat("MasterVolume", _volume);
    }

    public void SetMusicVolume(float _volume)
    {
        m_audioMixer.SetFloat("AmbientVolume", _volume);
    }

    public void SetSoundVolume(float _volume)
    {
        m_audioMixer.SetFloat("SoundVolume", _volume);
    }

    public void GameModeOn()
    {
        m_gameMode.TransitionTo(0.2f);
    }

    public void MenuModeOn()
    {
        m_menuMode.TransitionTo(0.2f);
    }
}
