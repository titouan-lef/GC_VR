using UnityEngine;
using UnityEngine.Audio;

public class SoundVolume
{
    private static SoundVolume _instance;

    // Sound and music volume [0, 100]
    private float _soundParam = 0;
    private float _musicParam = 0;

    public float SoundParam { get => _soundParam; set => _soundParam = value; }
    public float MusicParam { get => _musicParam; set => _musicParam = value; }

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
}
