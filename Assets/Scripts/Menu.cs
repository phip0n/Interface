using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    private string _masterVolumeName = nameof(AudioData.VolumeGroup.Master);
    private float _masterVolume;
    private bool _isSoundsOn = true;

    public void ToggleSound()
    {
        if (_isSoundsOn)
        {
            _isSoundsOn = false;
            _mixer.SetFloat(_masterVolumeName, AudioData.MinVolume);
        }
        else
        {
            _isSoundsOn = true;
            _mixer.SetFloat(_masterVolumeName, _masterVolume);
        }
    }

    public void ChangeVolume(string name, float volume)
    {
        if (name == _masterVolumeName)
        {
            _masterVolume = volume;

            if (_isSoundsOn)
            {
                _mixer.SetFloat(_masterVolumeName, volume);
            }
        }
        else
        {
            _mixer.SetFloat(name, volume);
        }
    }

    public float GetMixerValue(string name)
    {
        _mixer.GetFloat(name, out float result);
        return result;
    }
}
