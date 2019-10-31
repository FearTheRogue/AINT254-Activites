using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer m_audioMixer;


    public void SetMusicVolume(float _volume)
    {
        m_audioMixer.SetFloat("AmbientVolume", _volume);
    }
}
