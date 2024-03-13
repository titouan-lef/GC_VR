using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolume
{
    private static SoundVolume _instance;
    private float _soundParam = 1f;
    private float _musicParam = 1f;

    public static SoundVolume Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SoundVolume();
            }
            return _instance;
        }
    }

    public float SoundParam { get => _soundParam; set => _soundParam = value; }
    public float MusicParam { get => _musicParam; set => _musicParam = value; }
}
